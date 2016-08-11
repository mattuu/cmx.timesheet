using System;
using Cmx.Timesheet.Model;
using Cmx.Timesheet.Services;
using Nancy;
using Nancy.ModelBinding;

namespace Cmx.Timesheet.Api
{
    public sealed class TimesheetModule : NancyModule
    {
        private readonly ITimesheetProvider _timesheetProvider;

        public TimesheetModule(ITimesheetProvider timesheetProvider)
            : base("/api/timesheet")
        {
            if (timesheetProvider == null) throw new ArgumentNullException(nameof(timesheetProvider));
            _timesheetProvider = timesheetProvider;

            Get("", async _ => await _timesheetProvider.GetTimesheetListItems());

            Get<TimesheetDetailsItem>("/{id}", async parameters => await timesheetProvider.GetTimesheetDetailsById(parameters.id));

            Post<TimesheetDetailsItem>("", async _ =>
            {
                var model = this.Bind<TimesheetCreateItem>();
                return await timesheetProvider.CreateTimesheet(model);
            });

            Put<TimesheetDetailsItem>("/{id}", async parameters =>
            {
                var model = this.Bind<TimesheetUpdateItem>();
                return await _timesheetProvider.UpdateTimesheet(parameters.id, model);
            });

            //Put("/{id}/submit", async timesheetId =>
            //{
            //    _timesheetWorkflowService.SubmitTimesheet(timesheetId);
            //    return await Task.FromResult(HttpStatusCode.OK);
            //});
        }
    }
}