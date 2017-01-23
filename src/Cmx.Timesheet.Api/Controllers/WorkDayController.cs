using System;
using System.Threading.Tasks;
using System.Web.Http;
using Cmx.Timesheet.Api.Models;
using Cmx.Timesheet.Services;

namespace Cmx.Timesheet.Api.Controllers
{
    [RoutePrefix("api/workday")]
    public class WorkDayController : ApiController
    {
        private readonly IWorkDaySubmitService _workDaySubmitService;

        public WorkDayController(IWorkDaySubmitService workDaySubmitService)
        {
            if (workDaySubmitService == null) throw new ArgumentNullException(nameof(workDaySubmitService));
            _workDaySubmitService = workDaySubmitService;
        }

        [HttpPost]
        public async Task<IHttpActionResult> SubmitWorkDay(WorkDaySubmitItem item)
        {
            return Ok(await _workDaySubmitService.Submit(item));
        }
    }
}