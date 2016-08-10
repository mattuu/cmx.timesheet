using System;
using System.Collections.Generic;
using Cmx.Timesheet.DomainModel;
using Cmx.Timesheet.Services;
using Ploeh.AutoFixture;

namespace Cmx.Timesheet.DataAccess.Mocks
{
    public class TimesheetDataDataStoreMock : ITimesheetDataStore
    {
        private readonly Fixture _fixture;

        public TimesheetDataDataStoreMock()
        {
            _fixture = new Fixture();
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());
        }

        public IEnumerable<TimesheetModel> GetTimesheets()
        {
            var count = new Random().Next(10, 30);

            return _fixture.CreateMany<TimesheetModel>(count);
        }

        public IEnumerable<TimesheetModel> GetTimesheetsByUser(int ownerId)
        {
            throw new NotImplementedException();
        }

        public TimesheetModel GetTimesheetById(int timesheetId)
        {
            return _fixture.Build<TimesheetModel>()
                           .With(t => t.Id, timesheetId)
                           .Create();
        }

        public void DeleteTimesheet(int timesheetId)
        {
            throw new NotImplementedException();
        }

        public TimesheetModel InsertTimesheet(TimesheetModel timesheetModel)
        {
            throw new NotImplementedException();
        }

        public TimesheetModel UpdateTimesheet(TimesheetUpdateModel timesheetUpdateModel)
        {
            throw new NotImplementedException();
        }
    }
}