using System;
using System.Threading;
using System.Threading.Tasks;
using YamMQ.General.Configuration;
using YamMQ.General.Network;

namespace YamMQ.SimpleClient
{
    public interface IBusConfigurationFactory
    {
        IBusApiConfiguration CreateUsingNtlmAuthentication(string url);

        IBusApiConfiguration CreateUsingOAuthAuthentication(string url,
            Func<CancellationToken, Task<IHeader>> getNewOAuthTokenHeaderFunc);

        IBusApiConfiguration CreateWithoutAnyAuthentication(string url);
    }

    internal sealed class BusConfigurationFactory : IBusConfigurationFactory
    {
        private BusConfigurationFactory()
        {
        }

        public static IBusConfigurationFactory Instance { get; } = new BusConfigurationFactory();

        public IBusApiConfiguration CreateUsingNtlmAuthentication(string url)
            => new BusApiConfiguration(url, new NtlmBusApiSecurity());

        public IBusApiConfiguration CreateUsingOAuthAuthentication(string url,
                Func<CancellationToken, Task<IHeader>> getNewOAuthTokenHeaderFunc)
            => new BusApiConfiguration(url, new OAuthBusApiSecurity(getNewOAuthTokenHeaderFunc));

        public IBusApiConfiguration CreateWithoutAnyAuthentication(string url)
            => new BusApiConfiguration(url, new NoBusApiSecurityConfiguration());

        private sealed class BusApiConfiguration : IBusApiConfiguration
        {
            public BusApiConfiguration(string url, IBusApiSecurityConfiguration securityConfiguration)
            {
                Url = url;
                SecurityConfiguration = securityConfiguration;
            }

            public string Url { get; }
            public IBusApiSecurityConfiguration SecurityConfiguration { get; }
        }

        private sealed class NoBusApiSecurityConfiguration : IBusApiSecurityConfiguration
        {
        }

        private sealed class NtlmBusApiSecurity : INtlmBusApiSecurity
        {
        }

        private sealed class OAuthBusApiSecurity : IOAuthBusApiSecurity
        {
            private readonly Func<CancellationToken, Task<IHeader>> _getNewOAuthTokenHeaderFunc;

            public OAuthBusApiSecurity(Func<CancellationToken, Task<IHeader>> getNewOAuthTokenHeaderFunc)
            {
                _getNewOAuthTokenHeaderFunc = getNewOAuthTokenHeaderFunc;
            }

            public IHeader GetNewOAuthTokenHeader() => _getNewOAuthTokenHeaderFunc(default(CancellationToken)).Result;

            public Task<IHeader> GetNewOAuthTokenHeaderAsync(
                    CancellationToken cancellationToken = default(CancellationToken))
                => _getNewOAuthTokenHeaderFunc(cancellationToken);
        }
    }
}