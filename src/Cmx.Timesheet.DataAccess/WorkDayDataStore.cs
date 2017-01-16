using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cmx.Timesheet.DataAccess.Models;
using MongoDB.Driver;

namespace Cmx.Timesheet.DataAccess
{
    public class WorkDayDataStore : MongoDbDataStoreBase<WorkDayModel>, IWorkDayDataStore
    {
        public WorkDayDataStore(IMongoDatabase mongoDatabase, string collectionName)
            : base(mongoDatabase, collectionName)
        {
        }

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