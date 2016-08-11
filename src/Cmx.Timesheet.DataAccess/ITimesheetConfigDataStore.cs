using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cmx.Timesheet.DomainModel.Configuration;

namespace Cmx.Timesheet.DataAccess
{
    public interface ITimesheetConfigDataStore
    {
        Task<IEnumerable<TimesheetConfigModel>> GetTimesheetConfigurations();

        Task<TimesheetConfigModel> GetTimesheetConfigurationById(Guid timesheetConfigId);
    }
}
