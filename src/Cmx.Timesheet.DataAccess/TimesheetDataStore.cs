using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cmx.Timesheet.DataAccess.Models;
using MongoDB.Bson;
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
            return await MongoCollection.FindSync(tm => tm.Id == ObjectId.Parse(timesheetId.ToString()))
                                       .FirstAsync();
        }

        public Task<bool> UpdateTimesheet(TimesheetModel model)
        {
            throw new NotImplementedException();
        }

        public async Task<TimesheetModel> CreateTimesheet(TimesheetModel timesheetModel)
        {
            await MongoCollection.InsertOneAsync(timesheetModel);
            return await Task.FromResult(timesheetModel);
        }

        public Task<bool> DeleteTimesheet(Guid timesheetId)
        {
            throw new NotImplementedException();
        }
    }
}