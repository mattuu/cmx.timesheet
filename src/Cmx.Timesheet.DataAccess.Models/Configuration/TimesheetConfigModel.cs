using System;

namespace Cmx.Timesheet.DataAccess.Models.Configuration
{
    public class TimesheetConfigModel
    {
        public Guid? Id { get; set; }

        public TimesheetConfigModel()
        {
            ApplicableDays = new TimesheetApplicableWeekDays();
        }

        public TimeSpan DefaultStartTime { get; set; }

        public TimeSpan DefaultEndTime { get; set; }

        public TimeSpan DefaultBreakStartTime { get; set; }

        public TimeSpan DefaultBreakEndTime { get; set; }

        public TimesheetFrequency Frequency { get; set; }

        public TimesheetApplicableWeekDays ApplicableDays { get; set; }
    }
}