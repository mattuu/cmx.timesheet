using System;
using System.Collections.Generic;
using System.Linq;
using Cmx.Timesheet.DomainModel;

namespace Cmx.Timesheet.Website.Models.Timesheet
{
    public class CreateTimesheetViewModel
    {
        public DateTime StartDate { get; set; }
    }

    public class EditTimesheetViewModel 
    {
        private TimesheetModel _timesheet;
        private ICollection<CalendarDayViewModel> _calendar;

        public TimesheetModel Timesheet
        {
            get { return _timesheet; }
            set
            {
                _timesheet = value;
                foreach (var workDay in _timesheet.WorkDays)
                {
                    Calendar.Add(new CalendarDayViewModel
                    {
                        Id = workDay.Id,
                        Date = workDay.Date,
                        StartTime = workDay.StartTime,
                        EndTime = workDay.EndTime,
                        BreakStartTime = workDay.BreakStartTime,
                        BreakEndTime = workDay.BreakEndTime
                    });
                }
            }
        }

        public ICollection<CalendarDayViewModel> Calendar
        {
            get { return _calendar ?? (_calendar = new HashSet<CalendarDayViewModel>()); }
            set { _calendar = value; }
        }

        public TimesheetUpdateModel ToUpdateModel()
        {
            var model = new TimesheetUpdateModel
            {
                Id = Timesheet.Id,
                StartDate = Timesheet.StartDate,
                EndDate = Timesheet.EndDate,
                WorkDays = Calendar.Select(c => c.ToWorkDayModel()).ToList()
            };

            return model;
        }
    }
}