using System;
using System.Collections.Generic;
using System.Linq;

namespace Cmx.Timesheet.DataAccess.Models.Configuration
{
    public class TimesheetApplicableWeekDays
    {
        private readonly ICollection<DayOfWeek> _days;

        public TimesheetApplicableWeekDays()
        {
            _days = new HashSet<DayOfWeek>();
        }

        public TimesheetApplicableWeekDays(params int[] days)
            : this()
        {
            _days = days.Select(d => (DayOfWeek) d).Distinct().OrderBy(d => d).ToList();
        }

        public TimesheetApplicableWeekDays(params DayOfWeek[] days)
            : this()
        {
            _days = days.Distinct().OrderBy(d => d).ToList();
        }

        public bool Monday
        {
            get { return Days.Contains(DayOfWeek.Monday); }
        }

        public bool Tuesday
        {
            get { return Days.Contains(DayOfWeek.Tuesday); }
        }

        public bool Wednesday
        {
            get { return Days.Contains(DayOfWeek.Wednesday); }
        }

        public bool Thursday
        {
            get { return Days.Contains(DayOfWeek.Thursday); }
        }

        public bool Friday
        {
            get { return Days.Contains(DayOfWeek.Friday); }
        }

        public bool Saturday
        {
            get { return Days.Contains(DayOfWeek.Saturday); }
        }

        public bool Sunday
        {
            get { return Days.Contains(DayOfWeek.Sunday); }
        }

        public ICollection<DayOfWeek> Days
        {
            get { return _days; }
        }
    }

    public class TestP
    {
        public TestP()
        {
            
        }
        public string MyProperty { get; set; }

        public int Prop1 { get; set; }

        public DateTime DateTimeProperty { get; set; }
    }
}
