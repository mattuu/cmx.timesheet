using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Cmx.Timesheet.DomainModel;
using Cmx.Timesheet.Services;

namespace Cmx.Timesheet.WebApi
{
    [RoutePrefix("api")]
    public class TimesheetUserController : ApiController
    {
        private readonly ITimesheetStore _timesheetStore;
        private readonly ITimesheetWorkflowService _timesheetWorkflowService;

        public TimesheetUserController(ITimesheetStore timesheetStore, ITimesheetWorkflowService timesheetWorkflowService)
        {
            if (timesheetStore == null) throw new ArgumentNullException("timesheetStore");
            if (timesheetWorkflowService == null) throw new ArgumentNullException("timesheetWorkflowService");
            _timesheetStore = timesheetStore;
            _timesheetWorkflowService = timesheetWorkflowService;
        }

        [Route("timesheet")]
        [HttpGet]
        public async Task<HttpResponseMessage> GetTimesheetsByUser()
        {
            const int ownerId = 1; // TODO find user id in repo..
            var data = _timesheetStore.GetTimesheetsByUser(ownerId);
            return await Task.FromResult(Request.CreateResponse(HttpStatusCode.OK, data));
        }

        [Route("timesheet/{id}")]
        [HttpGet]
        public async Task<HttpResponseMessage> GetTimesheetById(int id)
        {
            var data = _timesheetStore.GetTimesheetById(id);
            return await Task.FromResult(Request.CreateResponse(HttpStatusCode.OK, data));
        }

        [Route("timesheet/{id}")]
        [HttpPost]
        public async Task<HttpResponseMessage> SaveTimesheet(int id, TimesheetUpdateModel model)
        {
            var data = _timesheetStore.GetTimesheetById(id);
            return await Task.FromResult(Request.CreateResponse(HttpStatusCode.OK, data));
        }

        [Route("timesheet/{id}/submit")]
        [HttpPut]
        public async Task<HttpResponseMessage> SubmitTimesheet(int id)
        {
            // TODO check if user can submit timesheet..
            _timesheetWorkflowService.SubmitTimesheet(id);
            return await Task.FromResult(Request.CreateResponse(HttpStatusCode.OK));
        }
    }
}