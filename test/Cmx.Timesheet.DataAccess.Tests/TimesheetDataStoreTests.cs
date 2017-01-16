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
        public async Task GetTimesheets_ShouldCall_GetCollection_On_MongoDatabase_WithCorrectArgs(
            [Frozen] Mock<IMongoDatabase> mongoDatabaseMock, TimesheetDataStore sut)
        {
            // act..
            await sut.GetTimesheets();

            // assert..
            mongoDatabaseMock.Verify(
                m =>
                    m.GetCollection<TimesheetModel>(
                        It.Is<string>(s => s == TimesheetDataStore.TimesheetCollectionName),
                        It.Is<MongoCollectionSettings>(s => s == null)), Times.Once());
        }

        [Theory(Skip = "TODO: come up with good way of testing this.."), AutoMoqData]
        public async Task GetTimesheets_ShouldCall_FindAsync_On_IMongoCollectionOfTimesheetModel(
            [Frozen] Mock<IMongoCollection<TimesheetModel>> mongoCollectionMock,
            TimesheetDataStore sut)
        {
            // act..
            await sut.GetTimesheets();

            // assert..
            //mongoCollectionMock.Verify(m => m.FindAsync(It.IsAny<FilterDefinition<TimesheetModel>>()), Times.Once());
        }


        [Theory, AutoMoqData]
        public async Task GetTimesheetById_ShouldCall_GetCollection_On_MongoDatabase_WithCorrectArgs(
            [Frozen] Mock<IMongoDatabase> mongoDatabaseMock, TimesheetDataStore sut)
        {
            // act..
            await sut.GetTimesheets();

            // assert..
            mongoDatabaseMock.Verify(
                m =>
                    m.GetCollection<TimesheetModel>(
                        It.Is<string>(s => s == TimesheetDataStore.TimesheetCollectionName),
                        It.Is<MongoCollectionSettings>(s => s == null)), Times.Once());
        }
    }
}