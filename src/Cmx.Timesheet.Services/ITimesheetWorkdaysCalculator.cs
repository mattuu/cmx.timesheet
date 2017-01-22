using System;
using System.Collections.Generic;
using Cmx.Timesheet.DataAccess.Models.Configuration;

namespace Cmx.Timesheet.Services
{
    public interface ITimesheetWorkdaysCalculator
    {
        IEnumerable<DateTime> Calculate(DateTime startDate, DateTime endDate, TimesheetFrequency frequency, TimesheetApplicableWeekDays weekDays);
    }
}