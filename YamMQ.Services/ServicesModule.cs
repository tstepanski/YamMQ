using Autofac;

namespace YamMQ.Services
{
    public sealed class ServicesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<MessageService>()
                .As<IMessageService>()
                .SingleInstance();
        }
    }
}