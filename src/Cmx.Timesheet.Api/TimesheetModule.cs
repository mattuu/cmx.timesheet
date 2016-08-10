using System;
using System.Threading.Tasks;
using Cmx.Timesheet.DomainModel;
using Cmx.Timesheet.Services;
using Nancy;

namespace Cmx.Timesheet.Api
{
    public sealed class TimesheetModule : NancyModule
    {
        private readonly ITimesheetStore _timesheetStore;
        private readonly ITimesheetWorkflowService _timesheetWorkflowService;

        public TimesheetModule(ITimesheetStore timesheetStore, ITimesheetWorkflowService timesheetWorkflowService)
            : base("/api/timesheet")
        {
            if (timesheetStore == null) throw new ArgumentNullException("timesheetStore");
            if (timesheetWorkflowService == null) throw new ArgumentNullException("timesheetWorkflowService");
            _timesheetStore = timesheetStore;
            _timesheetWorkflowService = timesheetWorkflowService;

            Get("", async _ =>
            {
                var data = _timesheetStore.GetTimesheets();
                return await Task.FromResult(data);
            });

            Get<TimesheetModel>("/{id}", async parameters =>
            {
                var data = _timesheetStore.GetTimesheetById(parameters.id);
                return await Task.FromResult(data);
            });

            Post("/{id}", async timesheetModel =>
            {
                _timesheetStore.InsertTimesheet(timesheetModel);
                return await Task.FromResult(HttpStatusCode.Created);
            });

            Put("/{id}/submit", async timesheetId =>
            {
                _timesheetWorkflowService.SubmitTimesheet(timesheetId);
                return await Task.FromResult(HttpStatusCode.OK);
            });
        }     
    }
}