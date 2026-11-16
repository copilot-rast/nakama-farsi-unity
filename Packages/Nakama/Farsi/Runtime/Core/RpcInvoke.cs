using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace NakamaFarsi.Sdk
{
    public static class RpcInvoke
    {
        public static async Task<T> CallAsync<T>(IRpcCaller caller, string id, object request, RpcCallOptions options, CancellationToken ct)
        {
            var body = await caller.CallRpcAsync(id, SdkJson.Serialize(request), options, ct).ConfigureAwait(false);
            try
            {
                return SdkJson.Response<T>(body);
            }
            catch (JsonException e)
            {
                throw new ApiException(ApiError.InvalidResponse(e.Message), e);
            }
        }
    }
}
