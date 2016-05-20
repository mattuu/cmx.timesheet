using System;
using System.Web.Mvc;
using Cmx.Timesheet.Services;
using Cmx.Timesheet.Website.Models.Timesheet;
using Cmx.Timesheet.Website.Controllers.Infrastructure;

namespace Cmx.Timesheet.Website.Controllers
{
    public class TimesheetController : AlertController
    {
        private readonly ITimesheetFactory _timesheetFactory;
        private readonly ITimesheetConfigurator _timesheetConfigurator;
        private readonly ITimesheetStore _timesheetStore;

        public TimesheetController(ITimesheetStore timesheetStore, ITimesheetFactory timesheetFactory, ITimesheetConfigurator timesheetConfigurator)
        {
            if (timesheetStore == null) throw new ArgumentNullException(nameof(timesheetStore));
            if (timesheetFactory == null) throw new ArgumentNullException(nameof(timesheetFactory));
            if (timesheetConfigurator == null) throw new ArgumentNullException(nameof(timesheetConfigurator));
            _timesheetStore = timesheetStore;
            _timesheetFactory = timesheetFactory;
            _timesheetConfigurator = timesheetConfigurator;
        }

        public ActionResult View(int id)
        {
            var timesheetModel = _timesheetStore.GetTimesheetById(id);

            var vm = new TimesheetViewModel(timesheetModel);

            return View(vm);
        }


        //// GET: Timesheet
        public ActionResult Save(TimesheetViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("CreateTimesheet", "User", viewModel);
            }

            _timesheetStore.UpdateTimesheet(viewModel.ToUpdateModel());

            return RedirectToAction("Index", "User");
        }

        public ActionResult Confirmation()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CreateTimesheetViewModel viewModel)
        {
            
            if (!ModelState.IsValid)
            {
                RedirectToAction("CreateTimesheet", "User", viewModel);
            }

            Success("Timesheet successfully created!", true);

            var timesheetConfig = _timesheetConfigurator.GetCurrentByUserId(0);
            var timesheetModel = _timesheetFactory.Create(timesheetConfig, viewModel.StartDate);
            _timesheetStore.InsertTimesheet(timesheetModel);

            var editViewModel = new EditTimesheetViewModel()
            {
                Timesheet = timesheetModel
            };
            
            return View("Edit", editViewModel);
        }

        [HttpPost]
        public ActionResult Edit(EditTimesheetViewModel viewModel)
        {

            if (!ModelState.IsValid)
            {
                Danger("There was a problem with your request. Please try again.", true);

                return View(viewModel);
                //RedirectToAction("CreateTimesheet", "User", viewModel);
            }

           
            _timesheetStore.UpdateTimesheet(viewModel.ToUpdateModel());
            //viewModel.Timesheet.Timesheet
            Success("Timesheet successfully saved!");

            return View(viewModel);
        }
    }
}