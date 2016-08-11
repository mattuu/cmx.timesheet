using System;
using Cmx.Timesheet.DomainModel;
using Cmx.Timesheet.DomainModel.Configuration;

namespace Cmx.Timesheet.Services
{
    public class TimesheetFactory : ITimesheetFactory
    {
        public TimesheetModel Create(TimesheetConfigModel configuration, DateTime startDate)
        {
            if (configuration == null) throw new ArgumentNullException("configuration");

            var timesheet = new TimesheetModel
            {
                StartDate = startDate
            };

            switch (configuration.Frequency)
            {
                case TimesheetFrequency.Monthly:
                    timesheet.EndDate = timesheet.StartDate.AddMonths(1);
                    break;
                case TimesheetFrequency.Weekly:
                    timesheet.EndDate = timesheet.StartDate.AddDays(7);
                    break;
                default:
                    throw new ArgumentOutOfRangeException("configuration");
            }

            for (var date = timesheet.StartDate; date < timesheet.EndDate; date = date.AddDays(1))
            {
                if (configuration.ApplicableDays.Days.Contains(date.DayOfWeek))
                {
                    //timesheet.WorkDays.Add(new WorkDayModel
                    //{
                    //    Date = date,
                    //    StartTime = configuration.DefaultStartTime,
                    //    EndTime = configuration.DefaultEndTime,
                    //    BreakStartTime = configuration.DefaultBreakStartTime,
                    //    BreakEndTime = configuration.DefaultBreakEndTime
                    //});
                }
            }

            return timesheet;
        }
    }
}