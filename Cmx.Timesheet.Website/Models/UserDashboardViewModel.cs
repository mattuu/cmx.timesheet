using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Routing;
using Cmx.Timesheet.Services;
using Cmx.Timesheet.Website.Models.Timesheet;

namespace Cmx.Timesheet.Website.Models
{
    public class UserDashboardViewModel
    {
        private readonly ITimesheetStore _timesheetStore;

        public UserDashboardViewModel(ITimesheetStore timesheetStore)
        {
            if (timesheetStore == null) throw new ArgumentNullException(nameof(timesheetStore));
            _timesheetStore = timesheetStore;

            var timesheets = _timesheetStore.GetTimesheetsByUser(0)
                .Select(t => new TimesheetViewModel(t));

            var actions = new HashSet<Tuple<string, string, Func<TimesheetViewModel, RouteValueDictionary>>>()
            {
                Tuple.Create<string, string, Func<TimesheetViewModel, RouteValueDictionary>>("View", "View", t => new RouteValueDictionary( new { controller = "Timesheet", id = t.Timesheet.Id}))
            };

            Timesheets = new TimesheetListViewModel(timesheets, actions);         
}

        public TimesheetViewModel MostRecetntTimesheet { get; set; }

        public TimesheetListViewModel Timesheets { get; private set; }
    }
}