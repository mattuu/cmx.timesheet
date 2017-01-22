using System;
using Cmx.Timesheet.DataAccess.Models;
using Cmx.Timesheet.DataAccess.Models.Configuration;

namespace Cmx.Timesheet.Services
{
    public class TimesheetFactory : ITimesheetFactory
    {
        private readonly ITimesheetDatesCalculator _timesheetDatesCalculator;

        public TimesheetFactory(ITimesheetDatesCalculator timesheetDatesCalculator)
        {
            if (timesheetDatesCalculator == null) throw new ArgumentNullException(nameof(timesheetDatesCalculator));
            _timesheetDatesCalculator = timesheetDatesCalculator;
        }

        public TimesheetModel Create(TimesheetConfigModel configuration, DateTime effectiveDate)
        {
            if (configuration == null) throw new ArgumentNullException(nameof(configuration));

            var timesheet = new TimesheetModel
            {
                StartDate = _timesheetDatesCalculator.CalculateStartDate(effectiveDate, configuration.Frequency),
                EndDate = _timesheetDatesCalculator.CalculateEndDate(effectiveDate, configuration.Frequency)
            };           

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