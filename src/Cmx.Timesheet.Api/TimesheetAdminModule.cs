using System;
using System.Threading.Tasks;
using Cmx.Timesheet.DataAccess;
using Cmx.Timesheet.Services;
using Nancy;

namespace Cmx.Timesheet.Api
{
    //[RoutePrefix("api/admin")]
    public sealed class TimesheetAdminModule : NancyModule
    {
        private readonly ITimesheetDataStore _timesheetDataStore;
        private readonly ITimesheetWorkflowService _timesheetWorkflowService;

        public TimesheetAdminModule(ITimesheetDataStore timesheetDataStore, ITimesheetWorkflowService timesheetWorkflowService)
        {
            if (timesheetDataStore == null) throw new ArgumentNullException("timesheetDataStore");
            if (timesheetWorkflowService == null) throw new ArgumentNullException("timesheetWorkflowService");
            _timesheetDataStore = timesheetDataStore;
            _timesheetWorkflowService = timesheetWorkflowService;
        }
    }
}