using Autofac;
using Autofac.Integration.WebApi;
using YamMQ.Services;

namespace YamMQ.Api
{
    public sealed class ApiModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule(new ServicesModule());

            builder.RegisterApiControllers(ThisAssembly);
        }
    }
}