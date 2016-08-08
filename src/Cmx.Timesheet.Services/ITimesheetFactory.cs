using System;
using Cmx.Timesheet.DomainModel;
using Cmx.Timesheet.DomainModel.Configuration;

namespace Cmx.Timesheet.Services
{
    public interface ITimesheetFactory
    {
        TimesheetModel Create(TimesheetConfigModel configuration, DateTime startDate);
    }
}