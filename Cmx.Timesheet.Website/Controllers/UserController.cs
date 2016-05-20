using System;
using System.Web.Mvc;
using Cmx.Timesheet.DomainModel;
using Cmx.Timesheet.DomainModel.Configuration;
using Cmx.Timesheet.Services;
using Cmx.Timesheet.Website.Models;
using Cmx.Timesheet.Website.Models.Timesheet;

namespace Cmx.Timesheet.Website.Controllers
{
    public class UserController : Controller
    {
        private readonly ITimesheetConfigurator _timesheetConfigurator;
        private readonly ITimesheetFactory _timesheetFactory;
        private readonly ITimesheetStore _timesheetStore;

        public UserController(ITimesheetConfigurator timesheetConfigurator, ITimesheetFactory timesheetFactory, ITimesheetStore timesheetStore)
        {
            if (timesheetConfigurator == null) throw new ArgumentNullException(nameof(timesheetConfigurator));
            if (timesheetFactory == null) throw new ArgumentNullException(nameof(timesheetFactory));
            if (timesheetStore == null) throw new ArgumentNullException(nameof(timesheetStore));
            _timesheetConfigurator = timesheetConfigurator;
            _timesheetFactory = timesheetFactory;
            _timesheetStore = timesheetStore;
        }

        // GET: Home
        public ActionResult Index()
        {
            var viewModel = new UserDashboardViewModel(_timesheetStore);
            return View(viewModel);
        }

        public ActionResult CreateTimesheet()
        {
            var viewModel = new CreateTimesheetViewModel()
            {
                StartDate = DateTime.Today
            };

            return View(viewModel);
        }

        //[HttpPost]
        //public ActionResult CreateTimesheet(TimesheetModel timesheetModel)
        //{
        //    return View(timesheetModel);
        //}
    }
}