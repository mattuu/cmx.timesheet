using System;
using System.Reflection;
using Ploeh.AutoFixture.Kernel;
using RazorEngine.Configuration;
using RazorEngine.Templating;

namespace Cmx.Timesheet.TestUtils.AutoFixtureCustomizations
{
    public class RazorEngineServiceCustomization : ISpecimenBuilder
    {
        private readonly Type _type;

        public RazorEngineServiceCustomization(Type type)
        {
            if (type == null) throw new ArgumentNullException(nameof(type));
            _type = type;
        }

        public object Create(object request, ISpecimenContext context)
        {
            var pi = request as ParameterInfo;
            if (pi == null || pi.ParameterType != typeof(IRazorEngineService))
            {
                return new NoSpecimen();
            }

            return RazorEngineService.Create(new TemplateServiceConfiguration
            {
                TemplateManager = new EmbeddedResourceTemplateManager(_type)
            });
        }
    }
}