using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cmx.Timesheet.DataAccess.Models;
using MongoDB.Driver;

namespace Cmx.Timesheet.DataAccess
{
    public class TimesheetDataStore : MongoDbDataStoreBase<TimesheetModel>, ITimesheetDataStore
    {
        internal const string TimesheetCollectionName = "timesheets";
        
        public TimesheetDataStore(IMongoDatabase mongoDatabase)
            :base(mongoDatabase, TimesheetCollectionName)
        {
        }

        public async Task<IEnumerable<TimesheetModel>> GetTimesheets()
        {
            return await MongoCollection.FindSync(tm => true)
                                       .ToListAsync();
        }

        public IEnumerable<TimesheetModel> GetTimesheetsByUser(int ownerId)
        {
            throw new NotImplementedException();
        }

        public async Task<TimesheetModel> GetTimesheetById(Guid timesheetId)
        {
            return await MongoCollection.FindSync(tm => tm.Id == timesheetId)
                                       .FirstAsync();
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