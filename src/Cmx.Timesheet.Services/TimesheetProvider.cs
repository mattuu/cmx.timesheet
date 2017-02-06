using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Cmx.Timesheet.Api.Models;
using Cmx.Timesheet.DataAccess;
using Cmx.Timesheet.DataAccess.Models;

namespace Cmx.Timesheet.Services
{
    public class TimesheetProvider : ITimesheetProvider
    {
        private readonly ITimesheetDataStore _timesheetDataStore;
        private readonly IMapper _mapper;

        public TimesheetProvider(ITimesheetDataStore timesheetDataStore, IMapper mapper)
        {
            if (timesheetDataStore == null) throw new ArgumentNullException(nameof(timesheetDataStore));
            if (mapper == null) throw new ArgumentNullException(nameof(mapper));
            _timesheetDataStore = timesheetDataStore;
            _mapper = mapper;
        }

        public Task<IEnumerable<TimesheetListItem>> GetTimesheetListItems()
        {
            var task = _timesheetDataStore.GetTimesheets();

            return Task.Factory.FromAsync(task, result =>
            {
                var originalTask = result as Task<IEnumerable<TimesheetModel>>;
                return originalTask?.Result.Select(t => _mapper.Map<TimesheetListItem>(t));
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
                        //TimesheetId = model.Id ?? default(Guid),
                        StartDate = model.StartDate,
                        EndDate = model.EndDate
                    };
                }
                return null;
            });
        }

        public Task<TimesheetDetailsItem> CreateTimesheet(TimesheetCreateItem timesheetCreateItem)
        {
            var timesheetModel = new TimesheetModel
            {
                CreatedBy = "USER",
                CreatedOn = DateTime.Now,
                Status = TimesheetStatus.New,
                StartDate = timesheetCreateItem.StartDate,
                EndDate = timesheetCreateItem.EndDate
            };
            var task = _timesheetDataStore.CreateTimesheet(timesheetModel);
            return Task.Factory.FromAsync(task, result =>
            {
                var originalTask = result as Task<TimesheetModel>;
                var model = originalTask?.Result;
                if (model != null)
                {
                    return new TimesheetDetailsItem
                    {
                        //TimesheetId = model.Id ?? default(Guid),
                        StartDate = model.StartDate,
                        EndDate = model.EndDate
                    };
                }
                return null;
            });
        }

        public Task<TimesheetDetailsItem> UpdateTimesheet(Guid timesheetId, TimesheetUpdateItem timesheetUpdateItem)
        {
            throw new NotImplementedException();

            //_timesheetDataStore.GetTimesheetById(timesheetId).ContinueWith(t =>
            //{
            //    //return Task.FromResult(new TimesheetDetailsItem());

            //    //var timesheetModel = t.Result;
            //    //timesheetModel.EndDate = timesheetUpdateItem.EndDate;
            //    //timesheetModel.StartDate = timesheetUpdateItem.StartDate;

            //    //var task = _timesheetDataStore.UpdateTimesheet(timesheetModel);

            //    //return Task.Factory.FromAsync(task, result =>
            //    //{
            //    //    var originalTask = result as Task<TimesheetModel>;
            //    //    var model = originalTask?.Result;
            //    //    if (model != null)
            //    //    {
            //    //        return new TimesheetDetailsItem
            //    //        {
            //    //            TimesheetId = model.Id ?? default(Guid),
            //    //            StartDate = model.StartDate,
            //    //            EndDate = model.EndDate
            //    //        };
            //    //    }
            //    //    return null;
            //    //});
            //});
        }

        public Task<TimesheetModel> GetByUserAndDate(Guid userId, DateTime dateTime)
        {
            throw new NotImplementedException();
        }
    }
}