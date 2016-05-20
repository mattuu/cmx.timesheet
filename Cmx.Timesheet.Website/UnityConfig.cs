using System;
using Cmx.Timesheet.Services;
using J2BI.Holidays.ProductBrief.Fakes;
using Microsoft.Practices.Unity;

namespace Cmx.Timesheet.Website
{
    public static class UnityConfig
    {
        public static IUnityContainer GetConfiguredContainer()
        {
            return Container.Value;
        }

        private static readonly Lazy<IUnityContainer> Container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();

            container.RegisterType<ITimesheetConfigurator, TimesheetConfigurator>();
            container.RegisterType<ITimesheetFactory, TimesheetFactory>();
            //container.RegisterType<ITimesheetStore, InMemoryTimesheetStore>();
            container.RegisterInstance<ITimesheetStore>(new InMemoryTimesheetStore());

            return container;
        });
    }
}