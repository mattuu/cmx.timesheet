using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cmx.Timesheet.DataAccess.Models;

namespace Cmx.Timesheet.DataAccess
{
    public class WorkDayDataStore : IWorkDayDataStore
    {
        public Task<IEnumerable<WorkDayModel>> GetWorkDaysByTimesheetId(Guid timesheetId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveWorkDay(WorkDayModel workDayModel)
        {
            throw new NotImplementedException();
        }
    }
}