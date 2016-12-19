using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cmx.Timesheet.DomainModel;

namespace Cmx.Timesheet.DataAccess
{
    public class TimesheetDataStore : ITimesheetDataStore
    {
        public Task<IEnumerable<TimesheetModel>> GetTimesheets()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TimesheetModel> GetTimesheetsByUser(int ownerId)
        {
            throw new NotImplementedException();
        }

        public Task<TimesheetModel> GetTimesheetById(Guid timesheetId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateTimesheet(TimesheetModel model)
        {
            throw new NotImplementedException();
        }

        public Task<TimesheetModel> CreateTimesheet(TimesheetModel timesheetModel)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteTimesheet(Guid timesheetId)
        {
            throw new NotImplementedException();
        }
    }
}
