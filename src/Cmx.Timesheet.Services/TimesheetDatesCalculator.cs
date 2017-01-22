using System;
using Cmx.Timesheet.DataAccess.Models.Configuration;

namespace Cmx.Timesheet.Services
{
    public interface ITimesheetDatesCalculator
    {
        DateTime CalculateStartDate(DateTime effectiveDate, TimesheetFrequency frequency);

        DateTime CalculateEndDate(DateTime effectiveDate, TimesheetFrequency frequency);
    }

    public class TimesheetDatesCalculator : ITimesheetDatesCalculator
    {
        public DateTime CalculateStartDate(DateTime effectiveDate, TimesheetFrequency frequency)
        {
            switch (frequency)
            {
                case TimesheetFrequency.Monthly:
                    return effectiveDate.AddDays(1 - effectiveDate.Day);
                case TimesheetFrequency.Weekly:
                    return
                        effectiveDate.AddDays(1 -
                                              (effectiveDate.DayOfWeek == DayOfWeek.Sunday
                                                  ? 7
                                                  : (int) effectiveDate.DayOfWeek));
                default:
                    throw new ArgumentOutOfRangeException(nameof(frequency));
            }
        }

        public DateTime CalculateEndDate(DateTime effectiveDate, TimesheetFrequency frequency)
        {
            var startDate = CalculateStartDate(effectiveDate, frequency).AddDays(-1);
            switch (frequency)
            {
                case TimesheetFrequency.Monthly:
                    return startDate.AddMonths(1);
                case TimesheetFrequency.Weekly:
                    return startDate.AddDays(7);
                default:
                    throw new ArgumentOutOfRangeException(nameof(frequency));
            }
        }
    }
}