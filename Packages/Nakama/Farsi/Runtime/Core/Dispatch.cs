using System;
using System.Threading;

namespace NakamaFarsi.Sdk
{
    public interface IMainThreadDispatcher
    {
        void Post(Action action);
    }

    public sealed class ImmediateDispatcher : IMainThreadDispatcher
    {
        public static readonly ImmediateDispatcher Instance = new ImmediateDispatcher();

        public void Post(Action action) => action?.Invoke();
    }

    public sealed class SynchronizationContextDispatcher : IMainThreadDispatcher
    {
        private readonly SynchronizationContext _context;

        public SynchronizationContextDispatcher(SynchronizationContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Post(Action action)
        {
            if (action == null)
            {
                return;
            }

            _context.Post(_ => action(), null);
        }
    }

    public interface IClock
    {
        DateTimeOffset UtcNow { get; }
    }

    public sealed class SystemClock : IClock
    {
        public static readonly SystemClock Instance = new SystemClock();

        public DateTimeOffset UtcNow => DateTimeOffset.UtcNow;
    }
}
