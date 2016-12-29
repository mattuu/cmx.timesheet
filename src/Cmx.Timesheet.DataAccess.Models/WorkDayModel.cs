using System;

namespace Cmx.Timesheet.DataAccess.Models
{
    public class WorkDayModel
    {
        public Guid? Id { get; set; }

        public Guid TimesheetId { get; set; }

        public DateTime Date { get; set; }

        public TimeSpan StartTime { get; set; }

        public TimeSpan EndTime { get; set; }

        public TimeSpan BreakDuration { get; set; }
    }
}