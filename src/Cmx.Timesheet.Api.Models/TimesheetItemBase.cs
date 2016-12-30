using System;

namespace Cmx.Timesheet.Api.Models
{
    public abstract class TimesheetItemBase
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}