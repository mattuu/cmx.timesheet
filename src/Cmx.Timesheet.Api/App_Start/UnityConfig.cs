using Cmx.Timesheet.DataAccess;
using Cmx.Timesheet.DataAccess.Mocks;
using Cmx.Timesheet.Services;
using Microsoft.Practices.Unity;

namespace Cmx.Timesheet.Api
{
    public static class UnityConfig
    {
        public static void RegisterComponents(IUnityContainer container)
        {
            RegisterServices(container);
            RegisterDataStores(container);
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
            container.RegisterType<ITimesheetDataStore, DocumentDbTimesheetDataStore>();
        }
    }
}