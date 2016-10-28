using System.Threading;
using System.Threading.Tasks;

namespace YamMQ.General.Network
{
    public interface IRestProxy
    {
        IRestResponse Execute(IRestRequest request);

        Task<IRestResponse> ExecuteAsync(IRestRequest request,
            CancellationToken cancellationToken = default(CancellationToken));
    }
}