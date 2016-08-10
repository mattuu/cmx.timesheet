using Microsoft.Practices.Unity;
using Nancy;
using Nancy.Bootstrappers.Unity;
using Nancy.Configuration;

namespace Cmx.Timesheet.Api
{
    public class NancyBootstrapper : UnityNancyBootstrapper
    {
        //protected override IRootPathProvider RootPathProvider => new CustomRootPathProvider();

        protected override INancyEnvironmentConfigurator GetEnvironmentConfigurator()
        {
            return ApplicationContainer.Resolve<INancyEnvironmentConfigurator>();
        }

        public override INancyEnvironment GetEnvironment()
        {
            return ApplicationContainer.Resolve<INancyEnvironment>();
        }

        protected override void RegisterNancyEnvironment(IUnityContainer container, INancyEnvironment environment)
        {
            container.RegisterInstance(environment);
        }

        protected override void ConfigureRequestContainer(IUnityContainer container, NancyContext context)
        {
            UnityConfig.RegisterComponents(container);

            //base.ConfigureRequestContainer(container, context);
        }
    }
}