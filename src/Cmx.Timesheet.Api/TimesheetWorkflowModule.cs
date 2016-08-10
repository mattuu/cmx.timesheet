using System.Threading.Tasks;
using Cmx.Timesheet.Services;
using Nancy;

namespace Cmx.Timesheet.Api
{
    public sealed class TimesheetWorkflowModule : NancyModule
    {
        public TimesheetWorkflowModule(ITimesheetWorkflowService timesheetWorkflowService)
            : base("/api/workflow")
        {
            Put("{id}/submit", async model =>
            {
                timesheetWorkflowService.SubmitTimesheet(model.id);
                return await Task.FromResult(HttpStatusCode.OK);
            });

            Put("{id}/approve", async model =>
            {
                timesheetWorkflowService.ApproveTimesheet(model.id);
                return await Task.FromResult(HttpStatusCode.OK);
            });

            Put("{id}/reject", async model =>
            {
                timesheetWorkflowService.RejectTimesheet(model.id);
                return await Task.FromResult(HttpStatusCode.OK);
            });
        }        
    }
}