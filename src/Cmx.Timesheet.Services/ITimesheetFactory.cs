using System;
using Cmx.Timesheet.DataAccess.Models;
using Cmx.Timesheet.DataAccess.Models.Configuration;

namespace Cmx.Timesheet.Services
{
    public interface ITimesheetFactory
    {
        TimesheetModel Create(TimesheetConfigModel configuration, DateTime startDate);
    }
}