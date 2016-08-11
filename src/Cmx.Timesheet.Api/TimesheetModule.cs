using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cmx.Timesheet.DataAccess;
using Cmx.Timesheet.DomainModel;
using Cmx.Timesheet.Services;
using Nancy;

namespace Cmx.Timesheet.Api
{
    public sealed class TimesheetModule : NancyModule
    {
        private readonly ITimesheetDataStore _timesheetDataStore;
        private readonly ITimesheetWorkflowService _timesheetWorkflowService;

        public TimesheetModule(ITimesheetDataStore timesheetDataStore, ITimesheetWorkflowService timesheetWorkflowService)
            : base("/api/timesheet")
        {
            if (timesheetDataStore == null) throw new ArgumentNullException("timesheetDataStore");
            if (timesheetWorkflowService == null) throw new ArgumentNullException("timesheetWorkflowService");
            _timesheetDataStore = timesheetDataStore;
            _timesheetWorkflowService = timesheetWorkflowService;

            Get("", async _ => await _timesheetDataStore.GetTimesheets());

            Get<TimesheetModel>("/{id}", async parameters => await _timesheetDataStore.GetTimesheetById(parameters.id));

            Post<TimesheetModel>("/{id}", async timesheetModel => await _timesheetDataStore.CreateTimesheet(timesheetModel));

            Put("/{id}/submit", async timesheetId =>
            {
                _timesheetWorkflowService.SubmitTimesheet(timesheetId);
                return await Task.FromResult(HttpStatusCode.OK);
            });
        }     
    }
}