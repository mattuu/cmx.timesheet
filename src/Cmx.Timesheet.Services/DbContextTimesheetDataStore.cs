using System.Collections.Generic;
using Cmx.Timesheet.DataAccess;
using Cmx.Timesheet.DomainModel;

namespace Cmx.Timesheet.Services
{
    public class DbContextTimesheetDataStore : ITimesheetDataStore
    {
        public IEnumerable<TimesheetModel> GetTimesheets()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<TimesheetModel> GetTimesheetsByUser(int ownerId)
        {
            throw new System.NotImplementedException();
        }

        public TimesheetModel GetTimesheetById(int timesheetId)
        {
            throw new System.NotImplementedException();
        }

        public TimesheetModel UpdateTimesheet(TimesheetUpdateModel timesheetModel)
        {
            throw new System.NotImplementedException();
        }

        public TimesheetModel InsertTimesheet(TimesheetModel timesheetModel)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteTimesheet(int timesheetId)
        {
            throw new System.NotImplementedException();
        }
    }
}