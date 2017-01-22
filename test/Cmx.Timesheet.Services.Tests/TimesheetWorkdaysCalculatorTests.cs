using System;
using System.Collections.Generic;
using System.Linq;
using Cmx.Timesheet.DataAccess.Models.Configuration;
using Cmx.Timesheet.TestUtils.Attributes;
using Ploeh.AutoFixture.Idioms;
using Shouldly;
using Xunit;

namespace Cmx.Timesheet.Services.Tests
{
    public class TimesheetWorkdaysCalculatorTests
    {
        [Theory, AutoMoqData]
        public void Ctor_ShouldThrowExceptionWhenAnyDependencyIsNull(GuardClauseAssertion assertion)
        {
            assertion.Verify(typeof(TimesheetWorkdaysCalculator).GetConstructors());
        }

        [Theory]
        [InlineAutoMoqData("2017/01/23", "2017/01/29", TimesheetFrequency.Weekly, new[] {1, 2, 3, 4, 5},
            typeof(WeeklyMonToFriTimesheetDates))]
        [InlineAutoMoqData("2017/01/01", "2017/01/31", TimesheetFrequency.Monthly, new[] {2, 3, 4},
            typeof(MonthlyTueToThuTimesheetDates))]
        public void Create_ShouldReturnCorrectResult(string startDateString,
            string endDateString,
            TimesheetFrequency frequency,
            int[] applicableWeekdays,
            Type expectedTimesheetDatesType,
            TimesheetWorkdaysCalculator sut)
        {
            // arrange..
            var startDate = DateTime.Parse(startDateString);
            var endDate = DateTime.Parse(endDateString);
            var weekdays = new TimesheetApplicableWeekDays(applicableWeekdays);

            var expected = (IEnumerable<DateTime>) Activator.CreateInstance(expectedTimesheetDatesType);

            // act..
            var actual = sut.Calculate(startDate, endDate, frequency, weekdays);

            // assert..
            actual.Select(wd => wd.Date).SequenceEqual(expected).ShouldBeTrue();
        }

        private class WeeklyMonToFriTimesheetDates : TimesheetDates
        {
            public WeeklyMonToFriTimesheetDates()
            {
                AddDate(23);
                AddDate(24);
                AddDate(25);
                AddDate(26);
                AddDate(27);
            }
        }

        private class MonthlyTueToThuTimesheetDates : TimesheetDates
        {
            public MonthlyTueToThuTimesheetDates()
            {
                AddDate(3);
                AddDate(4);
                AddDate(5);
                AddDate(10);
                AddDate(11);
                AddDate(12);
                AddDate(17);
                AddDate(18);
                AddDate(19);
                AddDate(24);
                AddDate(25);
                AddDate(26);
                AddDate(31);
            }
        }

        private abstract class TimesheetDates : List<DateTime>
        {
            private void AddDate(int year, int month, int day)
            {
                Add(new DateTime(year, month, day));
            }

            private void AddDate(int month, int day)
            {
                AddDate(2017, month, day);
            }

            protected void AddDate(int day)
            {
                AddDate(1, day);
            }
        }
    }
}