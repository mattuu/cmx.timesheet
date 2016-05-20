using System;
using System.Collections.Generic;
using System.Web.Routing;

namespace Cmx.Timesheet.Website.Models.Timesheet
{
    public class TimesheetListViewModel
    {
        public TimesheetListViewModel(IEnumerable<TimesheetViewModel> timesheets,
            IEnumerable<Tuple<string, string, Func<TimesheetViewModel, RouteValueDictionary>>> actionConfigs)
        {
            if (timesheets == null) throw new ArgumentNullException(nameof(timesheets));
            if (actionConfigs == null) throw new ArgumentNullException(nameof(actionConfigs));
            Timesheets = timesheets;
            ActionConfigs = actionConfigs;
        }

        public IEnumerable<TimesheetViewModel> Timesheets { get; }

        public IEnumerable<Tuple<string, string, Func<TimesheetViewModel, RouteValueDictionary>>> ActionConfigs { get; }
    }
}