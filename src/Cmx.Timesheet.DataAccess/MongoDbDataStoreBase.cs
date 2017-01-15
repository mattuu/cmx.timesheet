using System;
using MongoDB.Driver;

namespace Cmx.Timesheet.DataAccess
{
    public class MongoDbDataStoreBase<T>
    {
        public MongoDbDataStoreBase(IMongoDatabase mongoDatabase, string collectionName)
        {
            if (mongoDatabase == null) throw new ArgumentNullException(nameof(mongoDatabase));

            MongoCollection = mongoDatabase.GetCollection<T>(collectionName, new MongoCollectionSettings()
            {
                AssignIdOnInsert = true
            });
        }

        protected IMongoCollection<T> MongoCollection { get; }
    }
}