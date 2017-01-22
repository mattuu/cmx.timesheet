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
            throw new NotImplementedException();
        }

        public DateTime CalculateEndDate(DateTime effectiveDate, TimesheetFrequency frequency)
        {
            throw new NotImplementedException();
        }
    }
}