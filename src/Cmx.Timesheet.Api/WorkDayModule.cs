using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cmx.Timesheet.DataAccess;
using Cmx.Timesheet.DomainModel;
using Nancy;
using Nancy.ModelBinding;

namespace Cmx.Timesheet.Api
{
    public sealed class WorkDayModule : NancyModule
    {
        public WorkDayModule(IWorkDayDataStore workDayDataStore)
            : base("/api")
        {
            Get("timesheet/{id}/workdays", parameters => workDayDataStore.GetWorkDaysByTimesheetId(parameters.id));

            Post("timesheet/{id}/workday", async parameters =>
            {
                var workDayModel = this.Bind<WorkDayModel>();
                workDayModel.TimesheetId = parameters.id;
                return await workDayDataStore.SaveWorkDay(workDayModel);
            });
        }
    }
}