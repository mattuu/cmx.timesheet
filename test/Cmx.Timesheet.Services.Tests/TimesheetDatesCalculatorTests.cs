using System;
using Cmx.Timesheet.DataAccess.Models.Configuration;
using Cmx.Timesheet.TestUtils.Attributes;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.Idioms;
using Shouldly;
using Xunit;

namespace Cmx.Timesheet.Services.Tests
{
    public class TimesheetDatesCalculatorTests
    {
        [Theory, AutoMoqData]
        public void Ctor_ShouldThrowExceptionWhenAnyDependencyIsNull(GuardClauseAssertion assertion)
        {
            assertion.Verify(typeof(TimesheetDatesCalculator).GetConstructors());
        }

        [Theory]
        [InlineAutoMoqData("2017/01/01", TimesheetFrequency.Monthly, "2017/01/01")]
        [InlineAutoMoqData("2017/01/18", TimesheetFrequency.Monthly, "2017/01/01")]
        [InlineAutoMoqData("2017/01/31", TimesheetFrequency.Monthly, "2017/01/01")]
        [InlineAutoMoqData("2017/01/16", TimesheetFrequency.Weekly, "2017/01/16")]
        [InlineAutoMoqData("2017/01/18", TimesheetFrequency.Weekly, "2017/01/16")]
        [InlineAutoMoqData("2017/01/22", TimesheetFrequency.Weekly, "2017/01/16")]
        public void CalculateStartDate_ShouldReturnCorrectResult(
            string effectiveDateString,
            TimesheetFrequency timesheetFrequency,
            string expectedStartDateString,
            IFixture fixture,
            TimesheetDatesCalculator sut)
        {
            // arrange..
            var effectiveDate = DateTime.Parse(effectiveDateString);

            // act..
            var actual = sut.CalculateStartDate(effectiveDate, timesheetFrequency);

            // assert..
            var expectedStartDate = DateTime.Parse(expectedStartDateString);
            actual.ShouldBe(expectedStartDate);
        }

        [Theory]
        [InlineAutoMoqData("2017/01/01", TimesheetFrequency.Monthly, "2017/01/31")]
        [InlineAutoMoqData("2017/01/18", TimesheetFrequency.Monthly, "2017/01/31")]
        [InlineAutoMoqData("2017/01/31", TimesheetFrequency.Monthly, "2017/01/31")]
        [InlineAutoMoqData("2017/01/16", TimesheetFrequency.Weekly, "2017/01/22")]
        [InlineAutoMoqData("2017/01/18", TimesheetFrequency.Weekly, "2017/01/22")]
        [InlineAutoMoqData("2017/01/22", TimesheetFrequency.Weekly, "2017/01/22")]
        public void CalculateEndDate_ShouldReturnCorrectResult(
            string effectiveDateString,
            TimesheetFrequency timesheetFrequency,
            string expectedEndDateString,
            IFixture fixture,
            TimesheetDatesCalculator sut)
        {
            // arrange..
            var effectiveDate = DateTime.Parse(effectiveDateString);

            // act..
            var actual = sut.CalculateEndDate(effectiveDate, timesheetFrequency);

            // assert..
            var expectedStartDate = DateTime.Parse(expectedEndDateString);
            actual.ShouldBe(expectedStartDate);
        }
    }
}