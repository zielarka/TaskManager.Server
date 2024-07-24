using Autofac;
using TaskManager.Infrastructure.IoC.Modules;
using TaskManager.Infrastructure.Mappers;
using Microsoft.Extensions.Configuration;

namespace TaskManager.Infrastructure.IoC
{
    public class ContainerModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterInstance(AutoMapperConfig.Initialize())
                .SingleInstance();
            builder.RegisterModule<RepositoryModule>();
        }

    }
}
