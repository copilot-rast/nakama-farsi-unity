using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Nakama;

namespace NakamaFarsi.Sdk
{
    public sealed class SessionManager
    {
        private readonly IClient _client;
        private readonly IKeyValueStore _store;
        private readonly NakamaFarsiOptions _options;
        private readonly IClock _clock;
        private readonly ISdkLogger _logger;
        private readonly SemaphoreSlim _refreshLock = new SemaphoreSlim(1, 1);
        private readonly string _tokenKey;
        private readonly string _refreshKey;

        public SessionManager(IClient client, IKeyValueStore store, NakamaFarsiOptions options, IClock clock = null, ISdkLogger logger = null)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
            _store = store ?? new MemoryKeyValueStore();
            _options = options ?? new NakamaFarsiOptions();
            _clock = clock ?? SystemClock.Instance;
            _logger = logger ?? NullLogger.Instance;
            _tokenKey = _options.StorePrefix + "session.token";
            _refreshKey = _options.StorePrefix + "session.refresh";
            Restore();
        }

        public ISession Current { get; private set; }

        public bool IsLoggedIn => Current != null && (!Current.HasRefreshExpired(_clock.UtcNow.UtcDateTime) || !Current.HasExpired(_clock.UtcNow.UtcDateTime));

        public string UserId => Current?.UserId;

        public event Action<ISession> SessionChanged;

        public event Action SessionExpired;

        public async Task<ISession> AuthenticateDeviceAsync(string deviceId, bool create = true, string username = null, Dictionary<string, string> vars = null, CancellationToken ct = default)
        {
            if (string.IsNullOrWhiteSpace(deviceId))
            {
                throw new ApiException(ApiError.Invalid("deviceId", "device id is empty"));
            }

            var session = await Guard(() => _client.AuthenticateDeviceAsync(deviceId, username, create, vars, null, ct)).ConfigureAwait(false);
            Set(session);
            return session;
        }

        public async Task<ISession> AuthenticateEmailAsync(string email, string password, string username = null, bool create = false, CancellationToken ct = default)
        {
            var session = await Guard(() => _client.AuthenticateEmailAsync(email, password, username, create, null, null, ct)).ConfigureAwait(false);
            Set(session);
            return session;
        }

        public async Task<ISession> AuthenticateCustomAsync(string customId, string username = null, bool create = true, CancellationToken ct = default)
        {
            var session = await Guard(() => _client.AuthenticateCustomAsync(customId, username, create, null, null, ct)).ConfigureAwait(false);
            Set(session);
            return session;
        }

        public ISession Adopt(string token, string refreshToken = null)
        {
            var session = Session.Restore(token, refreshToken);
            Set(session);
            return session;
        }

        public async Task<ISession> EnsureAsync(CancellationToken ct = default)
        {
            var session = Current;
            if (session == null)
            {
                throw new ApiException(ApiError.NotLoggedIn());
            }

            var soon = _clock.UtcNow.UtcDateTime.AddSeconds(_options.RefreshAheadSeconds);
            if (!session.HasExpired(soon))
            {
                return session;
            }

            return await RefreshAsync(session, ct).ConfigureAwait(false);
        }

        public async Task<ISession> RefreshAsync(ISession stale = null, CancellationToken ct = default)
        {
            await _refreshLock.WaitAsync(ct).ConfigureAwait(false);
            try
            {
                var session = Current;
                if (session == null)
                {
                    throw new ApiException(ApiError.NotLoggedIn());
                }

                if (stale != null && !ReferenceEquals(stale, session) && !session.HasExpired(_clock.UtcNow.UtcDateTime.AddSeconds(_options.RefreshAheadSeconds)))
                {
                    return session;
                }

                if (string.IsNullOrEmpty(session.RefreshToken) || session.HasRefreshExpired(_clock.UtcNow.UtcDateTime))
                {
                    if (!session.HasExpired(_clock.UtcNow.UtcDateTime))
                    {
                        return session;
                    }

                    Expire("refresh token missing or expired");
                    throw new ApiException(new ApiError(ApiError.SessionExpiredCode, 401, string.Empty));
                }

                try
                {
                    var fresh = await _client.SessionRefreshAsync(session, null, null, ct).ConfigureAwait(false);
                    Set(fresh);
                    return fresh;
                }
                catch (ApiResponseException e) when (e.StatusCode == 401 || e.StatusCode == 403 || e.StatusCode == 404)
                {
                    Expire("refresh refused: " + e.Message);
                    throw new ApiException(new ApiError(ApiError.SessionExpiredCode, 401, string.Empty), e);
                }
                catch (ApiResponseException e)
                {
                    throw new ApiException(new ApiError(ErrorParser.CodeForStatus(e.StatusCode, e.Message), e.StatusCode, string.Empty), e);
                }
                catch (Exception e) when (!(e is ApiException) && !(e is OperationCanceledException && ct.IsCancellationRequested))
                {
                    throw new ApiException(ApiError.Network(e.Message), e);
                }
            }
            finally
            {
                _refreshLock.Release();
            }
        }

        public async Task LogoutAsync(CancellationToken ct = default)
        {
            var session = Current;
            Clear();
            if (session == null)
            {
                return;
            }

            try
            {
                await _client.SessionLogoutAsync(session, null, ct).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                _logger.Warn("Logout on the server failed: " + e.Message);
            }
        }

        public void Clear()
        {
            Current = null;
            _store.Delete(_tokenKey);
            _store.Delete(_refreshKey);
            _store.Save();
        }

        private void Expire(string why)
        {
            _logger.Warn("Session expired: " + why);
            Clear();
            SessionExpired?.Invoke();
        }

        private void Set(ISession session)
        {
            Current = session;
            _store.Set(_tokenKey, session.AuthToken);
            if (string.IsNullOrEmpty(session.RefreshToken))
            {
                _store.Delete(_refreshKey);
            }
            else
            {
                _store.Set(_refreshKey, session.RefreshToken);
            }

            _store.Save();
            SessionChanged?.Invoke(session);
        }

        private void Restore()
        {
            var token = _store.Get(_tokenKey);
            if (string.IsNullOrEmpty(token))
            {
                return;
            }

            try
            {
                var session = Session.Restore(token, _store.Get(_refreshKey));
                var now = _clock.UtcNow.UtcDateTime;
                if (session.HasExpired(now) && (string.IsNullOrEmpty(session.RefreshToken) || session.HasRefreshExpired(now)))
                {
                    Clear();
                    return;
                }

                Current = session;
            }
            catch (Exception e)
            {
                _logger.Warn("Stored session could not be read: " + e.Message);
                Clear();
            }
        }

        private static async Task<ISession> Guard(Func<Task<ISession>> call)
        {
            try
            {
                return await call().ConfigureAwait(false);
            }
            catch (ApiResponseException e)
            {
                throw new ApiException(ErrorParser.Parse(e.Message, e.StatusCode, null, null), e);
            }
            catch (TaskCanceledException e)
            {
                throw new ApiException(ApiError.Network(e.Message), e);
            }
            catch (Exception e) when (!(e is ApiException))
            {
                throw new ApiException(ApiError.Network(e.Message), e);
            }
        }
    }
}
