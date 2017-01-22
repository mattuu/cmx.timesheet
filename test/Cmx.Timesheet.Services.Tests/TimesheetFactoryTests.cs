using System;
using System.Collections.Generic;
using System.Linq;
using Cmx.Timesheet.DataAccess.Models;
using Cmx.Timesheet.DataAccess.Models.Configuration;
using Cmx.Timesheet.TestUtils.Attributes;
using Moq;
using Ploeh.AutoFixture.Idioms;
using Ploeh.AutoFixture.Xunit2;
using Ploeh.SemanticComparison.Fluent;
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
        public void Create_ShouldCreateInstanceOfTimesheetModel(TimesheetConfigModel config, DateTime startDate,
            TimesheetFactory sut)
        {
            // act..
            var actual = sut.Create(config, startDate);

            // assert..
            actual.ShouldNotBeNull();
        }

        [Theory]
        [InlineAutoMoqData(null)]
        public void Create_ThrowException_WhenTimesheetConfigModelIsNull(TimesheetConfigModel config, DateTime startDate,
            TimesheetFactory sut)
        {
            // act..
            var exception = Record.Exception(() => sut.Create(config, startDate));

            // assert..
            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<ArgumentNullException>();
        }

        [Theory, AutoMoqData]
        public void Create_ShouldCall_CalculateStartDate_On_ITimesheetDatesCalculator_WithCorrectArgs(
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
        public void Create_ShouldPopulate_TimesheetStartDate_WithCorrectValue(
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
            actual.StartDate.ShouldBe(startDate);
        }

        [Theory, AutoMoqData]
        public void Create_ShouldPopulate_TimesheetEndDate_WithCorrectValue(
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
        public void Create_ShouldCall_Calculate_On_ITimesheetWorkdaysCalculator_WithCorrectArgs(
            [Frozen] Mock<ITimesheetWorkdaysCalculator> timesheetWorkdaysCalculatorMock,
            [Frozen] Mock<ITimesheetDatesCalculator> timesheetDatesCalculatorMock,
            DateTime effectiveDate,
            DateTime startDate,
            DateTime endDate, 
            TimesheetConfigModel config,
            TimesheetFactory sut)
        {
            // arrange..
            timesheetDatesCalculatorMock.Setup(m => m.CalculateStartDate(effectiveDate, config.Frequency)).Returns(startDate);
            timesheetDatesCalculatorMock.Setup(m => m.CalculateEndDate(effectiveDate, config.Frequency)).Returns(endDate);

            // act..
            sut.Create(config, effectiveDate);

            // assert..
            timesheetWorkdaysCalculatorMock.Verify(m => m.Calculate(It.Is<DateTime>(d => d == startDate), 
                It.Is<DateTime>(d => d == endDate),
                It.Is<TimesheetFrequency>(f => f == config.Frequency),
                It.Is<TimesheetApplicableWeekDays>(wd => wd == config.ApplicableDays)), Times.Once());
        }

        [Theory, AutoMoqData]
        public void Create_ShouldPopulate_WorkDays_FromITimesheetWorkdaysCalculator(
          [Frozen] Mock<ITimesheetWorkdaysCalculator> timesheetWorkdaysCalculatorMock,
          [Frozen] Mock<ITimesheetDatesCalculator> timesheetDatesCalculatorMock,
          DateTime effectiveDate,
          DateTime startDate,
          DateTime endDate,
          IEnumerable<DateTime> workDays,
          TimesheetConfigModel config,
          TimesheetFactory sut)
        {
            // arrange..
            timesheetDatesCalculatorMock.Setup(m => m.CalculateStartDate(effectiveDate, config.Frequency)).Returns(startDate);
            timesheetDatesCalculatorMock.Setup(m => m.CalculateEndDate(effectiveDate, config.Frequency)).Returns(endDate);

            timesheetWorkdaysCalculatorMock.Setup(m => m.Calculate(startDate,endDate,config.Frequency,config.ApplicableDays)).Returns(workDays);

            // act..
            var actual = sut.Create(config, effectiveDate);

            // assert..
            var expectations = actual.WorkDays.Select(wd => wd.AsSource()
                .OfLikeness<DateTime>()
                .With(dt => dt.Date).EqualsWhen((m, dt) => m.Date == dt));

            expectations.Cast<object>().SequenceEqual(workDays.Cast<object>()).ShouldBeTrue();
        }
    }
}