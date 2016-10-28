using System.Collections.Generic;
using System.Net;

namespace YamMQ.General.Network
{
    public interface IRestResponse
    {
        IEnumerable<IHeader> Headers { get; }
        HttpStatusCode HttpStatusCode { get; }
        string ResponseBody { get; }
    }
}