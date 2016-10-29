using System.Web;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;

namespace YamMQ.Api
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            SetupDependencyInjection();

            GlobalConfiguration.Configure(WebApiConfig.Register);
        }

        private static void SetupDependencyInjection()
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterModule(new ApiModule());

            var container = containerBuilder.Build();
            var config = GlobalConfiguration.Configuration;

            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}