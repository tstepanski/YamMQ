using System.Collections.Generic;
using System.Linq;
using System.Net;
using YamMQ.General.Network;

namespace YamMQ.SimpleClient
{
    internal sealed class SimpleRestResponse : IRestResponse
    {
        private readonly IHeader[] _headers;

        public SimpleRestResponse(HttpStatusCode httpStatusCode, string responseBody, IEnumerable<IHeader> headers)
        {
            HttpStatusCode = httpStatusCode;
            ResponseBody = responseBody;
            _headers = headers.ToArray();
        }

        public IEnumerable<IHeader> Headers => _headers;
        public HttpStatusCode HttpStatusCode { get; }
        public string ResponseBody { get; }
    }
}