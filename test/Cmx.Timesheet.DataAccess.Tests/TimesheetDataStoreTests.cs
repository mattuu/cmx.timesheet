using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cmx.Timesheet.DataAccess.Models;
using Cmx.Timesheet.TestUtils.Attributes;
using MongoDB.Driver;
using Moq;
using Ploeh.AutoFixture.Idioms;
using Ploeh.AutoFixture.Xunit2;
using Xunit;

namespace Cmx.Timesheet.DataAccess.Tests
{
    public class TimesheetDataStoreTests
    {
        [Theory, AutoMoqData]
        public void Ctor_ShouldThrowWhenAnyDependencyIsNull(GuardClauseAssertion assertion)
        {
            assertion.Verify(typeof(TimesheetDataStore).GetConstructors());
        }

        [Theory, AutoMoqData]
        public async Task GetTimesheets_ShouldCall_GetCollection_On_MongoDatabase_WithCorrectArgs([Frozen] Mock<IMongoDatabase> mongoDatabaseMock, TimesheetDataStore sut)
        {
            // act..
            await sut.GetTimesheets();

            // assert..
            mongoDatabaseMock.Verify(m => m.GetCollection<TimesheetModel>(It.Is<string>(s => s == TimesheetDataStore.TimesheetCollectionName), It.Is<MongoCollectionSettings>(s => s == null)), Times.Once());
        }

        [Theory(Skip = "TODO: come up with good way of testing this.."), AutoMoqData]
        public async Task GetTimesheets_ShouldReturnCorrectResult([Frozen] Mock<IMongoDatabase> mongoDatabaseMock,
                                                                  [Frozen] Mock<IMongoCollection<TimesheetModel>> mongoCollectionMock,
                                                                  MongoCollectionSettings settings,
                                                                  IEnumerable<TimesheetModel> expectedTimesheetModels,
                                                                  TimesheetDataStore sut)
        {
            // arrange..
            mongoDatabaseMock.Setup(m => m.GetCollection<TimesheetModel>(TimesheetDataStore.TimesheetCollectionName, settings)).Returns(mongoCollectionMock.Object);

            // act..
            var actual = await sut.GetTimesheets();

            // assert..
            mongoDatabaseMock.Verify(m => m.GetCollection<TimesheetModel>(It.Is<string>(s => s == TimesheetDataStore.TimesheetCollectionName), It.Is<MongoCollectionSettings>(s => s == null)), Times.Once());
        }


        [Theory, AutoMoqData]
        public async Task GetTimesheetById_ShouldCall_GetCollection_On_MongoDatabase_WithCorrectArgs([Frozen] Mock<IMongoDatabase> mongoDatabaseMock, TimesheetDataStore sut)
        {
            // act..
            await sut.GetTimesheets();

            // assert..
            mongoDatabaseMock.Verify(m => m.GetCollection<TimesheetModel>(It.Is<string>(s => s == TimesheetDataStore.TimesheetCollectionName), It.Is<MongoCollectionSettings>(s => s == null)), Times.Once());
        }

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