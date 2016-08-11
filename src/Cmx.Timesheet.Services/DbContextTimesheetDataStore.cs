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

        public TimesheetModel UpdateTimesheet(TimesheetUpdateModel timesheetModel)
        {
            throw new System.NotImplementedException();
        }

        public Task<TimesheetModel> CreateTimesheet(TimesheetCreateModel timesheetCreateModel)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteTimesheet(int timesheetId)
        {
            throw new System.NotImplementedException();
        }
    }
}