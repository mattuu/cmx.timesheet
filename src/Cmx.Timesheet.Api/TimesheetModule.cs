using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cmx.Timesheet.DataAccess;
using Cmx.Timesheet.DomainModel;
using Cmx.Timesheet.Model;
using Cmx.Timesheet.Services;
using Nancy;

namespace Cmx.Timesheet.Api
{
    public sealed class TimesheetModule : NancyModule
    {
        private readonly ITimesheetProvider _timesheetProvider;
        private readonly ITimesheetWorkflowService _timesheetWorkflowService;

        public TimesheetModule(ITimesheetProvider timesheetProvider, ITimesheetWorkflowService timesheetWorkflowService)
            : base("/api/timesheet")
        {
            if (timesheetProvider == null) throw new ArgumentNullException(nameof(timesheetProvider));
            if (timesheetWorkflowService == null) throw new ArgumentNullException("timesheetWorkflowService");
            _timesheetProvider = timesheetProvider;
            _timesheetWorkflowService = timesheetWorkflowService;

            Get("", async _ => await _timesheetProvider.GetTimesheetListItems());

            Get<TimesheetDetailsItem>("/{id}", async parameters => await timesheetProvider.GetTimesheetDetailsById(parameters.id));

            //Post<TimesheetCreateItem>("/{id}", async timesheetModel => await _timesheetDataStore.CreateTimesheet(timesheetModel));

            Put("/{id}/submit", async timesheetId =>
            {
                _timesheetWorkflowService.SubmitTimesheet(timesheetId);
                return await Task.FromResult(HttpStatusCode.OK);
            });
        }     
    }
}