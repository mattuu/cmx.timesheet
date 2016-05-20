using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Cmx.Timesheet.DomainModel.Configuration;
using Cmx.Timesheet.Services;

namespace Cmx.Timesheet.WebApi
{
    [RoutePrefix("api/config")]
    public class TimesheetConfigurationController : ApiController
    {
        private readonly ITimesheetConfigurator _timesheetConfigurator;

        public TimesheetConfigurationController(ITimesheetConfigurator timesheetConfigurator)
        {
            if (timesheetConfigurator == null) throw new ArgumentNullException("timesheetConfigurator");
            _timesheetConfigurator = timesheetConfigurator;
        }


        [Route("timesheet/setup")]
        [HttpPost]
        public async Task<HttpResponseMessage> CreateUserTimesheetsConfig(int userId, TimesheetConfigModel timesheetConfigModel)
        {
            _timesheetConfigurator.CreateTimesheetConfiguration(userId, timesheetConfigModel);

            return await Task.FromResult(Request.CreateResponse(HttpStatusCode.OK));
        }
    }
}