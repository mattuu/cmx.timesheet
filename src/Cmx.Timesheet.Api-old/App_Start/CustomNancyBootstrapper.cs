using Cmx.Timesheet.Services;
using Microsoft.Practices.Unity;
using Nancy;
using Nancy.Bootstrappers.Unity;

namespace Cmx.Timesheet.WebApi
{
    public class CustomNancyBootstrapper : UnityNancyBootstrapper
    {
        protected override IRootPathProvider RootPathProvider => new CustomRootPathProvider();

        protected override void ConfigureRequestContainer(IUnityContainer container, NancyContext context)
        {
            container.RegisterType<ITimesheetFactory, TimesheetFactory>();
            container.RegisterType<ITimesheetStore, DbContextTimesheetStore>();

            base.ConfigureRequestContainer(container, context);
        }
    }
}