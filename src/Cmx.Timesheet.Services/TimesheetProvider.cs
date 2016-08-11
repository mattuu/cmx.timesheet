using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cmx.Timesheet.DataAccess;
using Cmx.Timesheet.DomainModel;
using Cmx.Timesheet.Model;

namespace Cmx.Timesheet.Services
{
    public class TimesheetProvider : ITimesheetProvider
    {
        private readonly ITimesheetDataStore _timesheetDataStore;

        public TimesheetProvider(ITimesheetDataStore timesheetDataStore)
        {
            if (timesheetDataStore == null) throw new ArgumentNullException(nameof(timesheetDataStore));
            _timesheetDataStore = timesheetDataStore;
        }

        public Task<IEnumerable<TimesheetListItem>> GetTimesheetListItems()
        {
            var task = _timesheetDataStore.GetTimesheets();

            return Task.Factory.FromAsync(task, result =>
            {
                var originalTask = result as Task<IEnumerable<TimesheetModel>>;
                return originalTask?.Result.Select(t => new TimesheetListItem
                {
                    TimesheetId = t.Id ?? default(Guid),
                    StartDate = t.StartDate,
                    EndDate = t.EndDate,
                    Status = t.Status
                });
            });
        }

        public Task<TimesheetDetailsItem> GetTimesheetDetailsById(Guid timesheetId)
        {
            var task = _timesheetDataStore.GetTimesheetById(timesheetId);

            return Task.Factory.FromAsync(task, result =>
            {
                var originalTask = result as Task<TimesheetModel>;
                var model = originalTask?.Result;
                if (model != null)
                {
                    return new TimesheetDetailsItem
                    {
                        TimesheetId = model.Id ?? default(Guid),
                        StartDate = model.StartDate,
                        EndDate = model.EndDate
                    };
                }
                return null;
            });
        }
    }
}