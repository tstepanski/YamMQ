using System.Collections.Generic;

namespace YamMQ.General.Network
{
    public interface IRestRequest
    {
        HttpMethod HttpMethod { get; }
        string Url { get; }
        IEnumerable<IHeader> Headers { get; }
        string RequestBody { get; }
        bool UseNtlm { get; }
    }
}