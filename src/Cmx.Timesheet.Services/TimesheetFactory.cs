using System;
using System.Linq;
using Cmx.Timesheet.DataAccess.Models;
using Cmx.Timesheet.DataAccess.Models.Configuration;

namespace Cmx.Timesheet.Services
{
    public class TimesheetFactory : ITimesheetFactory
    {
        private readonly ITimesheetDatesCalculator _timesheetDatesCalculator;
        private readonly ITimesheetWorkdaysCalculator _timesheetWorkdaysCalculator;

        public TimesheetFactory(ITimesheetDatesCalculator timesheetDatesCalculator, ITimesheetWorkdaysCalculator timesheetWorkdaysCalculator)
        {
            if (timesheetDatesCalculator == null) throw new ArgumentNullException(nameof(timesheetDatesCalculator));
            if (timesheetWorkdaysCalculator == null)
                throw new ArgumentNullException(nameof(timesheetWorkdaysCalculator));
            _timesheetDatesCalculator = timesheetDatesCalculator;
            _timesheetWorkdaysCalculator = timesheetWorkdaysCalculator;
        }

        public TimesheetModel Create(TimesheetConfigModel configuration, DateTime effectiveDate)
        {
            if (configuration == null) throw new ArgumentNullException(nameof(configuration));

            var startDate = _timesheetDatesCalculator.CalculateStartDate(effectiveDate, configuration.Frequency);
            var endDate = _timesheetDatesCalculator.CalculateEndDate(effectiveDate, configuration.Frequency);
            var workdays = _timesheetWorkdaysCalculator.Calculate(startDate, endDate, configuration.Frequency, configuration.ApplicableDays);
            
            var timesheet = new TimesheetModel
            {
                StartDate = startDate,
                EndDate = endDate,
                WorkDays = workdays.Select(date => new WorkDayModel
                {
                    Date = date,
                    StartTime = configuration.DefaultStartTime,
                    EndTime = configuration.DefaultEndTime,
                    BreakDuration = configuration.DefaultBreakEndTime.Subtract(configuration.DefaultBreakStartTime)
                })    
            };           
          
            return timesheet;
        }
    }
}