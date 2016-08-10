using System;
using System.Threading.Tasks;
using Cmx.Timesheet.Services;
using Nancy;

namespace Cmx.Timesheet.Api
{
    //[RoutePrefix("api/config")]
    public sealed class TimesheetConfigurationModule : NancyModule
    {
        private readonly ITimesheetConfigurator _timesheetConfigurator;

        public TimesheetConfigurationModule(ITimesheetConfigurator timesheetConfigurator)
        {
            if (timesheetConfigurator == null) throw new ArgumentNullException("timesheetConfigurator");
            _timesheetConfigurator = timesheetConfigurator;

            Post("/setup", async model =>
            {
                _timesheetConfigurator.CreateTimesheetConfiguration(0, model);
                return await Task.FromResult(HttpStatusCode.Created);
            });
        }


        //[Route("timesheet/setup")]
        //[HttpPost]
        //public async Task<HttpResponseMessage> CreateUserTimesheetsConfig(int userId, TimesheetConfigModel timesheetConfigModel)
        //{
        //    _timesheetConfigurator.CreateTimesheetConfiguration(userId, timesheetConfigModel);

        //    return await Task.FromResult(Request.CreateResponse(HttpStatusCode.OK));
        //}
    }
}