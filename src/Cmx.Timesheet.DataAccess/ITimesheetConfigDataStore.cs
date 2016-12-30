using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cmx.Timesheet.DataAccess.Models.Configuration;

namespace Cmx.Timesheet.DataAccess
{
    public interface ITimesheetConfigDataStore
    {
        Task<IEnumerable<TimesheetConfigModel>> GetTimesheetConfigurations();

        Task<TimesheetConfigModel> GetTimesheetConfigurationById(Guid timesheetConfigId);
    }
}
