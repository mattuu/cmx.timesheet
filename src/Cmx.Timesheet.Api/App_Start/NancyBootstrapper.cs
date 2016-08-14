using Microsoft.Practices.Unity;
using Nancy;
using Nancy.Bootstrappers.Unity;
using Nancy.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Cmx.Timesheet.Api
{
    public class NancyBootstrapper : UnityNancyBootstrapper
    {
        public override void Configure(INancyEnvironment environment)
        {
            base.Configure(environment); 

            environment.Tracing(false, true);
        }

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
        }

        protected override void ConfigureApplicationContainer(IUnityContainer existingContainer)
        {
            base.ConfigureApplicationContainer(existingContainer);

            existingContainer.RegisterType<JsonSerializer, CustomJsonSerializer>();
        }
    }

    public sealed class CustomJsonSerializer : JsonSerializer
    {
        public CustomJsonSerializer()
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver();
            Formatting = Formatting.Indented;
            TypeNameHandling = TypeNameHandling.Objects;

        }
    }
}