using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cmx.Timesheet.DataAccess;
using Cmx.Timesheet.DomainModel;

namespace Cmx.Timesheet.Services
{
    public class DbContextTimesheetDataStore : ITimesheetDataStore
    {
        public Task<IEnumerable<TimesheetModel>> GetTimesheets()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<TimesheetModel> GetTimesheetsByUser(int ownerId)
        {
            throw new System.NotImplementedException();
        }

        public Task<TimesheetModel> GetTimesheetById(Guid timesheetId)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> UpdateTimesheet(TimesheetModel model)
        {
            throw new System.NotImplementedException();
        }

        public Task<TimesheetModel> CreateTimesheet(TimesheetModel timesheetCreateModel)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> DeleteTimesheet(Guid timesheetId)
        {
            throw new System.NotImplementedException();
        }
    }
}