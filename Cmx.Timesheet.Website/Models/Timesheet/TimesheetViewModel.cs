using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Cmx.Timesheet.DomainModel;

namespace Cmx.Timesheet.Website.Models.Timesheet
{
    public class TimesheetViewModel
    {
        public TimesheetModel Timesheet { get; }

        public TimesheetViewModel()
        {
            Calendar = new HashSet<CalendarDayViewModel>();
        }

        public TimesheetViewModel(TimesheetModel timesheetModel)
        {
            if (timesheetModel == null) throw new ArgumentNullException(nameof(timesheetModel));
            Timesheet = timesheetModel;
            Calendar = BuildCalendar(timesheetModel);
        }

        public IEnumerable<CalendarDayViewModel> Calendar { get; }

        private IEnumerable<CalendarDayViewModel> BuildCalendar(TimesheetModel timesheetModel)
        {
            var calendar = new HashSet<CalendarDayViewModel>();

            foreach (var workDay in timesheetModel.WorkDays)
            {
                calendar.Add(new CalendarDayViewModel()
                {
                    Id = workDay.Id,
                    Date = workDay.Date,
                    StartTime = workDay.StartTime,
                    EndTime = workDay.EndTime,
                    BreakStartTime = workDay.BreakStartTime,
                    BreakEndTime = workDay.BreakEndTime
                });
            }
            return calendar;
        }

        public TimesheetUpdateModel ToUpdateModel()
        {
            var model = new TimesheetUpdateModel
            {
                Id = Timesheet.Id,
                StartDate = Timesheet.StartDate,
                EndDate =  Timesheet.EndDate,
                WorkDays = Calendar.Select(c => c.ToWorkDayModel()).ToList()
            };

            return model;
        }
    }

    public class CalendarDayViewModel
    {   
        public int Id { get; set; }

        public DateTime Date { get; set; }

        [Required]
        [Description("Start Time")]
        [Display(Name = "Start Time")]
        public TimeSpan? StartTime { get; set; }

        [Required]
        public TimeSpan? EndTime { get; set; }

        [Required]
        public TimeSpan? BreakStartTime { get; set; }

        [Required]
        public TimeSpan? BreakEndTime { get; set; }

        public TimeSpan? TotalHours
        {
            get
            {
                if (!StartTime.HasValue || !EndTime.HasValue || !BreakStartTime.HasValue || !BreakEndTime.HasValue)
                {
                    return null;
                }

                var breakDuration = BreakEndTime.Value.Subtract(BreakStartTime.Value);
                var dayDuration = EndTime.Value.Subtract(StartTime.Value);

                return dayDuration.Subtract(breakDuration);

            }
        }

        // TODO validation..

        public WorkDayModel ToWorkDayModel()
        {
            return new WorkDayModel
            {
                Id = Id,
                Date = Date,
                StartTime = StartTime ?? TimeSpan.Zero,
                EndTime = EndTime ?? TimeSpan.Zero,
                BreakStartTime = BreakStartTime ?? TimeSpan.Zero,
                BreakEndTime = BreakEndTime ?? TimeSpan.Zero
            };
        }
    }
}