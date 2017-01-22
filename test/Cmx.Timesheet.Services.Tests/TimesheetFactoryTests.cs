using System;
using Cmx.Timesheet.DataAccess.Models.Configuration;
using Cmx.Timesheet.TestUtils.Attributes;
using Moq;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.Idioms;
using Ploeh.AutoFixture.Xunit2;
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
        public void Initialize_ShouldCreateTimesheetInstance(TimesheetConfigModel config, DateTime startDate,
            TimesheetFactory sut)
        {
            // act..
            var actual = sut.Create(config, startDate);

            // assert..
            actual.ShouldNotBeNull();
        }
        
        [Theory, AutoMoqData]
        public void Initialize_ShouldCall_CalculateStartDate_On_ITimesheetDatesCalculator_WithCorrectArgs(
            DateTime effectiveDate,
            TimesheetConfigModel timesheetConfigModel,
            [Frozen] Mock<ITimesheetDatesCalculator> timesheetEndDateCalculatorMock,
            TimesheetFactory sut)
        {
            // act..
            sut.Create(timesheetConfigModel, effectiveDate);

            // assert..
            timesheetEndDateCalculatorMock.Verify(
                m =>
                    m.CalculateStartDate(It.Is<DateTime>(dt => dt == effectiveDate),
                        It.Is<TimesheetFrequency>(f => f == timesheetConfigModel.Frequency)), Times.Once());
        }

        [Theory, AutoMoqData]
        public void Initialize_ShouldPopulate_TimesheetStartDate_WithCorrectValue(
            DateTime effectiveDate,
            DateTime startDate,
            TimesheetConfigModel timesheetConfigModel,
            [Frozen] Mock<ITimesheetDatesCalculator> timesheetDatesCalculatorMock,
            TimesheetFactory sut)
        {
            // arrange..
            timesheetDatesCalculatorMock.Setup(m => m.CalculateStartDate(effectiveDate, timesheetConfigModel.Frequency))
                .Returns(startDate);

            // act..
            var actual = sut.Create(timesheetConfigModel, effectiveDate);

            // assert..
            actual.EndDate.ShouldBe(startDate);
        }

        [Theory, AutoMoqData]
        public void Initialize_ShouldCall_CalculateEndDate_On_ITimesheetDatesCalculator_WithCorrectArgs(
            DateTime startDate,
            TimesheetConfigModel timesheetConfigModel,
            [Frozen] Mock<ITimesheetDatesCalculator> timesheetEndDateCalculatorMock,
            TimesheetFactory sut)
        {
            // act..
            sut.Create(timesheetConfigModel, startDate);

            // assert..
            timesheetEndDateCalculatorMock.Verify(
                m =>
                    m.CalculateEndDate(It.Is<DateTime>(dt => dt == startDate),
                        It.Is<TimesheetFrequency>(f => f == timesheetConfigModel.Frequency)), Times.Once());
        }

        [Theory, AutoMoqData]
        public void Initialize_ShouldPopulate_TimesheetEndDate_WithCorrectValue(
            DateTime effectiveDate,
            DateTime endDate,
            TimesheetConfigModel timesheetConfigModel,
            [Frozen] Mock<ITimesheetDatesCalculator> timesheetDatesCalculatorMock,
            TimesheetFactory sut)
        {
            // arrange..
            timesheetDatesCalculatorMock.Setup(m => m.CalculateEndDate(effectiveDate, timesheetConfigModel.Frequency))
                .Returns(endDate);

            // act..
            var actual = sut.Create(timesheetConfigModel, effectiveDate);

            // assert..
            actual.EndDate.ShouldBe(endDate);
        }

        [Theory, AutoMoqData]
        public void Initialize_ShouldCalculateCorrectTimesheetEndDate_WhenConfigFrequencyIsWeekly(IFixture fixture,
            DateTime startDate, TimesheetFactory sut)
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
        public void Initialize_ShouldCalculateCorrectWorkDays_When_TimesheetFrequencyIsMonthly(IFixture fixture,
            DateTime startDate, TimesheetFactory sut)
        {
            // arrange..
            var config = fixture.Build<TimesheetConfigModel>()
                .With(m => m.ApplicableDays, new TimesheetApplicableWeekDays(1, 2, 3, 4, 5))
                .With(m => m.Frequency, TimesheetFrequency.Monthly)
                .Create();

            // act..
            var actual = sut.Create(config, startDate);

            // assert..
            var workDays = actual.WorkDays;


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