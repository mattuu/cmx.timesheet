using System;

namespace Cmx.Timesheet.Model
{
    public abstract class WorkDayUpdateItemBase
    {
        public TimeSpan StartTime { get; set; }

        public TimeSpan EndTime { get; set; }

        public TimeSpan BreakDuration { get; set; }
    }
}