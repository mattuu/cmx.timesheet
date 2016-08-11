using System;
using System.Collections.Generic;

namespace Cmx.Timesheet.Model
{
    public class TimesheetDetailsItem
    {
        public TimesheetDetailsItem()
        {
            WorkDays = new HashSet<WorkDayListItem>();
        }

        public Guid TimesheetId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public IEnumerable<WorkDayListItem> WorkDays { get; set; }
    }
}