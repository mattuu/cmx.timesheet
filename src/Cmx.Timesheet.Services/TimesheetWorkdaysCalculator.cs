using System;
using System.Collections.Generic;
using Cmx.Timesheet.DataAccess.Models.Configuration;

namespace Cmx.Timesheet.Services
{
    public class TimesheetWorkdaysCalculator : ITimesheetWorkdaysCalculator
    {
        public IEnumerable<DateTime> Calculate(DateTime startDate, DateTime endDate, TimesheetFrequency frequency, TimesheetApplicableWeekDays weekDays)
        {
            var result = new HashSet<DateTime>();
            for (var date = startDate; date <= endDate; date = date.AddDays(1))
            {
                if (weekDays.Days.Contains(date.DayOfWeek))
                {
                    result.Add(date);
                }
            }

            return result;
        }
    }
}
