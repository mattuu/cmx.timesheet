using System;
using System.Threading.Tasks;
using System.Web.Http;
using Cmx.Timesheet.Services;

namespace Cmx.Timesheet.Api.Controllers
{
    [RoutePrefix("api/timesheet")]
    public class TimesheetController : ApiController
    {
        private readonly ITimesheetProvider _timesheetProvider;

        public TimesheetController(ITimesheetProvider timesheetProvider)
        {
            if (timesheetProvider == null) throw new ArgumentNullException(nameof(timesheetProvider));
            _timesheetProvider = timesheetProvider;
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetAll()
        {
            return Ok(await _timesheetProvider.GetTimesheetListItems());
        }
    }
}