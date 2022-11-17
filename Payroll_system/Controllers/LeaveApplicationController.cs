using Payroll_system.ApplicationDb;
using Payroll_system.Models;
using Microsoft.AspNetCore.Mvc;
using Payroll_system.ViewModels;
using Payroll_system.Services;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Payroll_system.Controllers
{
    public class LeaveApplicationController : Controller
    {
        private LeaveApplicationService _leaveApplicationService;

        public LeaveApplicationController(LeaveApplicationService leaveApplicationService)
        {
            _leaveApplicationService = leaveApplicationService;
        }

        public IActionResult Index(string searchString, DateTime? fromDate, DateTime? toDate)
        {
            var query = _leaveApplicationService.GetAll(searchString, fromDate, toDate);

            ViewData["searchString"] = searchString;
            ViewData["fromDate"] = fromDate;
            ViewData["toDate"] = toDate;

            return View(query);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(LeaveApllicationViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                _leaveApplicationService.Create(viewModel);
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }

        public IActionResult Update(int id)
        {
            if(id == 0)
            {
                return NotFound();
            }
            var updateLeaveApplicatioin = _leaveApplicationService.GetById(id);

            if(updateLeaveApplicatioin == null)
            {
                return NotFound();
            }

            return View(updateLeaveApplicatioin);
        }

        [HttpPost]
        public IActionResult Update(LeaveApllicationViewModel viewModel)
        {
            if(ModelState.IsValid)
            {
                _leaveApplicationService.Update(viewModel);
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }

        public IActionResult Delete(int id)
        {
            if(id == 0)
            {
                return NotFound();
            }
            var deleteApplication = _leaveApplicationService.GetById(id);

            if(deleteApplication == null)
            {
                return NotFound();
            }

            return View(deleteApplication);
        }

        [HttpPost]
        public IActionResult DeleteAll(int id)
        {
            if(id == 0)
            {
                return NotFound();
            }
            _leaveApplicationService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
