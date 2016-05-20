using System;
using Cmx.Timesheet.DomainModel.Configuration;

namespace Cmx.Timesheet.Services
{
    public class TimesheetConfigurator : ITimesheetConfigurator
    {
        public void CreateTimesheetConfiguration(int userId, TimesheetConfigModel timesheetConfigModel)
        {
            throw new NotImplementedException();
        }

        public TimesheetConfigModel GetCurrentByUserId(int userId)
        {
            var timesheetConfig = new TimesheetConfigModel
            {
                ApplicableDays = new TimesheetApplicableWeekDays(1, 2, 3, 4, 5),
                Frequency = TimesheetFrequency.Weekly,
                DefaultStartTime = new TimeSpan(8, 0, 0),
                DefaultEndTime = new TimeSpan(17, 0, 0),
                DefaultBreakStartTime = new TimeSpan(12, 0, 0),
                DefaultBreakEndTime = new TimeSpan(13, 0, 0)
            };

            return timesheetConfig;
        }
    }
}