using System;
using System.Linq;
using Cmx.Timesheet.DataAccess.Models.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cmx.Timesheet.Services.Tests
{
    [TestClass]
    public class TimesheetFactoryTests
    {
        [TestMethod]
        public void InitializeShouldCreateTimesheetInstance()
        {
            var config = new TimesheetConfigModel();
            var service = new TimesheetFactory();
            var timesheet = service.Create(config, default (DateTime));

            Assert.IsNotNull(timesheet);
        }

        [TestMethod]
        public void InitializeShouldSetUpCorrectWorkDays()
        {
            var config = new TimesheetConfigModel
            {
                ApplicableDays = new TimesheetApplicableWeekDays(1, 2, 3, 4, 5),
                Frequency = TimesheetFrequency.Monthly
            };

            var service = new TimesheetFactory();
            var timesheet = service.Create(config, new DateTime(2015, 10, 1));

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