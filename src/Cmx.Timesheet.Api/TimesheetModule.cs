using System;
using System.Threading.Tasks;
using Cmx.Timesheet.Services;
using Nancy;

namespace Cmx.Timesheet.Api
{
    //[RoutePrefix("api")]
    public sealed class TimesheetModule : NancyModule
    {
        private readonly ITimesheetStore _timesheetStore;
        private readonly ITimesheetWorkflowService _timesheetWorkflowService;

        public TimesheetModule(ITimesheetStore timesheetStore, ITimesheetWorkflowService timesheetWorkflowService)
            : base("/timesheet")
        {
            if (timesheetStore == null) throw new ArgumentNullException("timesheetStore");
            if (timesheetWorkflowService == null) throw new ArgumentNullException("timesheetWorkflowService");
            _timesheetStore = timesheetStore;
            _timesheetWorkflowService = timesheetWorkflowService;

            Get("", async _ =>
            {
                const int ownerId = 1; // TODO find user id in repo..
                var data = _timesheetStore.GetTimesheetsByUser(ownerId);
                return await Task.FromResult(data);
            });

            //Get("/{id}", async id =>
            //{
            //    var data = _timesheetStore.GetTimesheetById(id);
            //    return await Task.FromResult(data);
            //});

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

        //[Route("timesheet")]
        //[HttpGet]
        //public async Task<HttpResponseMessage> GetTimesheetsByUser()
        //{
        //    const int ownerId = 1; // TODO find user id in repo..
        //    var data = _timesheetStore.GetTimesheetsByUser(ownerId);
        //    return await Task.FromResult(Request.CreateResponse(HttpStatusCode.OK, data));
        //}

        //[Route("timesheet/{id}")]
        //[HttpGet]
        //public async Task<HttpResponseMessage> GetTimesheetById(int id)
        //{
        //    var data = _timesheetStore.GetTimesheetById(id);
        //    return await Task.FromResult(Request.CreateResponse(HttpStatusCode.OK, data));
        //}

        //[Route("timesheet/{id}")]
        //[HttpPost]
        //public async Task<HttpResponseMessage> SaveTimesheet(int id, TimesheetUpdateModel model)
        //{
        //    var data = _timesheetStore.GetTimesheetById(id);
        //    return await Task.FromResult(Request.CreateResponse(HttpStatusCode.OK, data));
        //}

        //[Route("timesheet/{id}/submit")]
        //[HttpPut]
        //public async Task<HttpResponseMessage> SubmitTimesheet(int id)
        //{
        //    // TODO check if user can submit timesheet..
        //    _timesheetWorkflowService.SubmitTimesheet(id);
        //    return await Task.FromResult(Request.CreateResponse(HttpStatusCode.OK));
        //}
    }
}