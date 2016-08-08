using System;

namespace Cmx.Timesheet.DomainModel
{
    public class WorkDayModel
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public TimeSpan StartTime { get; set; }

        public TimeSpan EndTime { get; set; }
        
        public TimeSpan BreakStartTime { get; set; }

        public TimeSpan BreakEndTime { get; set; }
    }
}