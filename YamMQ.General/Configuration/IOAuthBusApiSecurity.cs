using System.Threading;
using System.Threading.Tasks;
using YamMQ.General.Network;

namespace YamMQ.General.Configuration
{
    public interface IOAuthBusApiSecurity : IBusApiSecurityConfiguration
    {
        IHeader GetNewOAuthTokenHeader();
        Task<IHeader> GetNewOAuthTokenHeaderAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}