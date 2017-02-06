using Cmx.Timesheet.DataAccess.Models;
using Cmx.Timesheet.TestUtils.Attributes;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;
using Shouldly;
using Xunit;

namespace Cmx.Timesheet.DataAccess.IntegrationTests
{
    public class WorkDayDataStoreTests
    {
        [Theory, AutoMoqData]
        public void SaveWorkDay_ShouldSaveDataInMongoDb(WorkDayModel model)
        {
            var client = new MongoClient(new MongoUrl("mongodb://cmx_timesheet_full:3v*k0d'0=9z5?oS@ds135798.mlab.com:35798/cmx_timesheet"));
            ConventionRegistry.Register("camel case",
                new ConventionPack { new CamelCaseElementNameConvention() },
                t => t.FullName.StartsWith("Cmx.Timesheet.DataAccess."));

            var db = client.GetDatabase("cmx_timesheet");

            var collection = db.GetCollection<WorkDayModel>("workdays");

            collection.InsertOne(model);        

            var filter = new FilterDefinitionBuilder<WorkDayModel>().Where(m => m.Id == model.Id);

            var list = collection.Find(filter).First();
            
            list.ShouldNotBeNull();
            //list.TimesheetId.ShouldBe(model.TimesheetId);

            collection.DeleteOne(filter);
        }
    }
}