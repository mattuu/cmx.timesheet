using System;

namespace Cmx.Timesheet.Api.Models
{
    public abstract class WorkDayUpdateItemBase
    {
        public DateTime Date { get; set; }

        public TimeSpan StartTime { get; set; }

        public TimeSpan EndTime { get; set; }

        public TimeSpan BreakDuration { get; set; }
    }
}