using System.Configuration;
using System.Web.Http;
using Cmx.Timesheet.DataAccess;
using Cmx.Timesheet.Services;
using Microsoft.Practices.Unity;
using Unity.WebApi;

namespace Cmx.Timesheet.Api
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);

            RegisterServices(container);
            RegisterDataStores(container);
            RegisterProviders(container);

            DataAccess.UnityConfig.RegisterTypes(container);
        }

        private static void RegisterServices(IUnityContainer container)
        {
            container.RegisterType<ITimesheetFactory, TimesheetFactory>();
            container.RegisterType<ITimesheetWorkflowService, TimesheetWorkflowService>();
            container.RegisterType<ITimesheetConfigurator, TimesheetConfigurator>();
        }

        private static void RegisterDataStores(IUnityContainer container)
        {
            container.RegisterType<IWorkDayDataStore, DocumentDbWorkDayDataStore>();
            container.RegisterType<ITimesheetDataStore, TimesheetDataStore>();
        }

        private static void RegisterProviders(IUnityContainer container)
        {
            container.RegisterType<ITimesheetProvider, TimesheetProvider>();
        }

    }
}