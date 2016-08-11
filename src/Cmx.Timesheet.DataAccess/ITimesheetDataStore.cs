using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cmx.Timesheet.DomainModel;

namespace Cmx.Timesheet.DataAccess
{
    public interface ITimesheetDataStore
    {
        Task<IEnumerable<TimesheetModel>> GetTimesheets();

        IEnumerable<TimesheetModel> GetTimesheetsByUser(int ownerId);

        Task<TimesheetModel> GetTimesheetById(Guid timesheetId);

        TimesheetModel UpdateTimesheet(TimesheetUpdateModel timesheetUpdateModel);

        Task<TimesheetModel> CreateTimesheet(TimesheetCreateModel timesheetCreateModel);

        void DeleteTimesheet(int timesheetId);
    }
}
