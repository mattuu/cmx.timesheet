using System;
using Cmx.Timesheet.DomainModel;
using Cmx.Timesheet.TestUtils.Attributes;
using MongoDB.Driver;
using Xunit;

namespace Cmx.Timesheet.DataAccess.Tests
{
    public class TimesheetDataStoreTests
    {
        [Theory, AutoMoqData]
        public void GetTimesheets_ShouldReturnCorrectResult()
        {
            // arrange..
            var outputFileName = string.Empty;
            var client = new MongoClient(new MongoUrl("mongodb://cmx_timesheet_full:3v*k0d'0=9z5?oS@ds135798.mlab.com:35798/cmx_timesheet"));


            var db = client.GetDatabase("cmx_timesheet");

            var collection = db.GetCollection<TimesheetModel>("timesheets");

            var filter = new FilterDefinitionBuilder<TimesheetModel>().Empty;

            var count = collection.Count(filter);

            Console.WriteLine(count);
        }
    }
}
