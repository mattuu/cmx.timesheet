using System;
using Cmx.Timesheet.DataAccess.Models;
using Cmx.Timesheet.TestUtils.Attributes;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;
using Xunit;

namespace Cmx.Timesheet.DataAccess.IntegrationTests
{
    public class TimesheetDataStoreTests
    {
        [Theory, AutoMoqData]
        public void GetTimesheets_ShouldReturnCorrectResult()
        {
            // arrange..
            var client = new MongoClient(new MongoUrl("mongodb://cmx_timesheet_full:3v*k0d'0=9z5?oS@ds135798.mlab.com:35798/cmx_timesheet"));
            ConventionRegistry.Register("camel case",
                                        new ConventionPack { new CamelCaseElementNameConvention() },
                                        t => t.FullName.StartsWith("Cmx.Timesheet.DataAccess."));

            var db = client.GetDatabase("cmx_timesheet");

            var collection = db.GetCollection<TimesheetModel>("timesheets");

            var filter = new FilterDefinitionBuilder<TimesheetModel>().Empty;

            var list = collection.Find(t => true).First();

            var count = collection.Count(filter);

            Console.WriteLine(count);
        }
    }
}
