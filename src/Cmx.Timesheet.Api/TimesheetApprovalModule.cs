using System;
using System.Threading.Tasks;
using Cmx.Timesheet.Services;
using Nancy;
using HttpStatusCode = System.Net.HttpStatusCode;

namespace Cmx.Timesheet.Api
{
    //[RoutePrefix("api/approver")]
    public sealed class TimesheetApprovalModule : NancyModule
    {
        private readonly ITimesheetStore _timesheetStore;
        private readonly ITimesheetWorkflowService _timesheetWorkflowService;

        public TimesheetApprovalModule(ITimesheetStore timesheetStore, ITimesheetWorkflowService timesheetWorkflowService)
            : base("/api")
        {
            if (timesheetStore == null) throw new ArgumentNullException("timesheetStore");
            if (timesheetWorkflowService == null) throw new ArgumentNullException("timesheetWorkflowService");
            _timesheetStore = timesheetStore;
            _timesheetWorkflowService = timesheetWorkflowService;

            Get("/timesheet", async _ =>
            {
                var data = _timesheetStore.GetTimesheets();
                return await Task.FromResult(data);
            });

            Get("/timesheet/{id}", async (id, token) =>
            {
                var data = _timesheetStore.GetTimesheetById(id);
                return await Task.FromResult(data);
                return data;
            });

            Put("/timesheet/{id}/approve", async id =>
            {
                // TODO check if user can approve timesheet..

                _timesheetWorkflowService.ApproveTimesheet(id);

                return await Task.FromResult(HttpStatusCode.OK);
            });

            Put("/timesheet/{id}/reject", async id =>
            {
                // TODO check if user can reject timesheet..

                _timesheetWorkflowService.RejectTimesheet(id);

                return await Task.FromResult(HttpStatusCode.OK);
            });
        }

        //[Route("timesheet")]
        //[HttpGet]
        //public async Task<HttpResponseMessage> GetTimesheets()
        //{
            
        //}

        //[Route("timesheet/{id}")]
        //[HttpGet]
        //public async Task<HttpResponseMessage> GetTimesheet(int id)
        //{
        //    var data = _timesheetStore.GetTimesheetById(id);
        //    return await Task.FromResult(Request.CreateResponse(HttpStatusCode.OK, data));
        //}

     

        //[Route("timesheet/{id}/approve")]
        //[HttpPut]
        //public async Task<HttpResponseMessage> Approve(int id)
        //{
        //    // TODO check if user can approve timesheet..

        //    _timesheetWorkflowService.ApproveTimesheet(id);

        //    return await Task.FromResult(Request.CreateResponse(HttpStatusCode.OK));
        //}

        //[Route("timesheet/{id}/reject")]
        //[HttpPut]
        //public async Task<HttpResponseMessage> Reject(int id)
        //{
        //    // TODO check if user can approve timesheet..

        //    _timesheetWorkflowService.RejectTimesheet(id);

        //    return await Task.FromResult(Request.CreateResponse(HttpStatusCode.OK));
        //}
    }
}