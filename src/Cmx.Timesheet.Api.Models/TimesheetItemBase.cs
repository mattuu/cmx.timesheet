using System;

namespace Cmx.Timesheet.Model
{
    public abstract class TimesheetItemBase
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}