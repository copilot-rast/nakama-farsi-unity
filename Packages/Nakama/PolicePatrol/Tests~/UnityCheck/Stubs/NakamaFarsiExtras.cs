using System;

namespace UnityEngine
{
    [AttributeUsage(AttributeTargets.Field)]
    public sealed class TextAreaAttribute : Attribute
    {
    }

    [AttributeUsage(AttributeTargets.Field)]
    public sealed class TooltipAttribute : Attribute
    {
        public TooltipAttribute(string tooltip) { }
    }
}

namespace Nakama
{
    public sealed class UnityWebRequestAdapter : IHttpAdapter
    {
        public static UnityWebRequestAdapter Instance { get; } = new UnityWebRequestAdapter();

        public ILogger Logger { get; set; }

        public TransientExceptionDelegate TransientExceptionDelegate => null;

        public System.Threading.Tasks.Task<string> SendAsync(string method, Uri uri, System.Collections.Generic.IDictionary<string, string> headers, byte[] body, int timeoutSec = 3, System.Threading.CancellationToken? userCancelToken = null) =>
            throw new NotSupportedException();
    }

    public static class UnityClientStubExtensions
    {
        public static ISocket NewSocket(this IClient client, bool useMainThread = false) => Socket.From(client);
    }
}
