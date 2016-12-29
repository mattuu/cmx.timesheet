using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cmx.Timesheet.DataAccess.Models;
using MongoDB.Driver;

namespace Cmx.Timesheet.DataAccess
{
    public class TimesheetDataStore : ITimesheetDataStore
    {
        internal const string TimesheetCollectionName = "timesheets";
        private readonly IMongoDatabase _mongoDatabase;
        private IMongoCollection<TimesheetModel> _collection;

        public TimesheetDataStore(IMongoDatabase mongoDatabase)
        {
            if (mongoDatabase == null) throw new ArgumentNullException(nameof(mongoDatabase));
            _mongoDatabase = mongoDatabase;

            _collection = mongoDatabase.GetCollection<TimesheetModel>(TimesheetCollectionName, new MongoCollectionSettings
            {
                AssignIdOnInsert = true
            });
        }

        public async Task<IEnumerable<TimesheetModel>> GetTimesheets()
        {
            return await _mongoDatabase.GetCollection<TimesheetModel>(TimesheetCollectionName)
                                       .FindSync(tm => true)
                                       .ToListAsync();
        }

        public IEnumerable<TimesheetModel> GetTimesheetsByUser(int ownerId)
        {
            throw new NotImplementedException();
        }

        public async Task<TimesheetModel> GetTimesheetById(Guid timesheetId)
        {
            return await _mongoDatabase.GetCollection<TimesheetModel>(TimesheetCollectionName)
                                       .FindSync(tm => tm.Id == timesheetId)
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