using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cmx.Timesheet.DomainModel;

namespace Cmx.Timesheet.DataAccess
{
    public interface IWorkDayDataStore
    {
        Task<IEnumerable<WorkDayModel>> GetWorkDaysByTimesheetId(Guid timesheetId);

        Task<bool> SaveWorkDay(WorkDayModel workDayModel);
    }
}