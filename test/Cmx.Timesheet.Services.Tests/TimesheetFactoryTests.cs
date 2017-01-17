using System;
using Cmx.Timesheet.DataAccess.Models.Configuration;
using Cmx.Timesheet.TestUtils.Attributes;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.Idioms;
using Shouldly;
using Xunit;

namespace Cmx.Timesheet.Services.Tests
{
    public class TimesheetFactoryTests
    {
        [Theory, AutoMoqData]
        public void Ctor_ShouldThrowExceptionWhenAnyDependencyIsNull(GuardClauseAssertion assertion)
        {
            assertion.Verify(typeof(TimesheetFactory).GetConstructors());
        }

        [Theory, AutoMoqData]
        public void Initialize_ShouldCreateTimesheetInstance(TimesheetConfigModel config, DateTime startDate, TimesheetFactory sut)
        {
            // act..
            var actual = sut.Create(config, startDate);

            // assert..
            actual.ShouldNotBeNull();
        }

        [Theory, AutoMoqData]
        public void Initialize_ShouldPopulateStartDate(TimesheetConfigModel configModel, DateTime startDate, TimesheetFactory sut)
        {
            // arrange..
            var actual = sut.Create(configModel, startDate);

            // assert..
            actual.StartDate.ShouldBe(startDate);
        }


        [Theory, AutoMoqData]
        public void Initialize_ShouldCalculateCorrectTimesheetEndDate_WhenConfigFrequencyIsMonthly(IFixture fixture, DateTime startDate, TimesheetFactory sut)
        {
            // arrange..
            var config = fixture.Build<TimesheetConfigModel>()
                                .With(m => m.Frequency, TimesheetFrequency.Monthly)
                                .Create();

            // act..
            var actual = sut.Create(config, startDate);

            // assert..
            actual.EndDate.ShouldBe(startDate.AddMonths(1));
        }

        [Theory, AutoMoqData]
        public void Initialize_ShouldCalculateCorrectTimesheetEndDate_WhenConfigFrequencyIsWeekly(IFixture fixture, DateTime startDate, TimesheetFactory sut)
        {
            // arrange..
            var config = fixture.Build<TimesheetConfigModel>()
                                .With(m => m.Frequency, TimesheetFrequency.Weekly)
                                .Create();

            // act..
            var actual = sut.Create(config, startDate);

            // assert..
            actual.EndDate.ShouldBe(startDate.AddDays(7));
        }

        [Theory, AutoMoqData]
        public void Initialize_ShouldCalculateCorrectWorkDays(IFixture fixture, DateTime startDate, TimesheetFactory sut)
        {
            // arrange..
            var config = fixture.Build<TimesheetConfigModel>()
                                .With(m => m.ApplicableDays, new TimesheetApplicableWeekDays(1, 2, 3, 4, 5))
                                .With(m => m.Frequency, TimesheetFrequency.Monthly)
                                .Create();

            var timesheet = sut.Create(config, startDate);

            //var workDays = timesheet.WorkDays;
            //Assert.AreEqual(22, workDays.Count);
            //Assert.AreEqual(new DateTime(2015, 10, 1), workDays.First().Date);
            //Assert.AreEqual(new DateTime(2015, 10, 30), workDays.Last().Date);

            //Assert.IsTrue(workDays.All(wd => wd.StartTime == config.DefaultStartTime));
            //Assert.IsTrue(workDays.All(wd => wd.EndTime == config.DefaultEndTime));
            //Assert.IsTrue(workDays.All(wd => wd.BreakStartTime == config.DefaultBreakStartTime));
            //Assert.IsTrue(workDays.All(wd => wd.BreakEndTime == config.DefaultBreakEndTime));

            //Assert.IsTrue(workDays.All(wd => wd.Date.DayOfWeek != DayOfWeek.Saturday));
            //Assert.IsTrue(workDays.All(wd => wd.Date.DayOfWeek != DayOfWeek.Sunday));
        }
    }
}