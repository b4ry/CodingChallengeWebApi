using Autofac;
using System.Reflection;

namespace KnockKnockReadifyChallenge.Api.DependencyInjection
{
    public class InjectionModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            RegisterServices(builder);
        }

        private void RegisterServices(ContainerBuilder builder)
        {
            var repositoryAssembly = Assembly.Load("KnockKnockReadifyChallenge.Services");

            builder
                .RegisterAssemblyTypes(repositoryAssembly)
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}
