using System.Collections.Generic;
using YamMQ.General.Network;

namespace YamMQ.Client.Network
{
    internal sealed class PostMessageRequest : IRestRequest
    {
        public PostMessageRequest(string url, string serializedMessage,
            IEnumerable<IHeader> headers = null, bool useNtlm = false)
        {
            Url = url;
            RequestBody = serializedMessage;
            Headers = headers ?? new IHeader[0];
            UseNtlm = useNtlm;
        }

        public HttpMethod HttpMethod => HttpMethod.Post;
        public string Url { get; }
        public IEnumerable<IHeader> Headers { get; }
        public string RequestBody { get; }
        public bool UseNtlm { get; }
    }
}