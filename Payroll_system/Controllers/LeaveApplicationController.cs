﻿using Payroll_system.ApplicationDb;
using Payroll_system.Models;
using Microsoft.AspNetCore.Mvc;
using Payroll_system.ViewModels;
using Payroll_system.Services;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Payroll_system.Controllers
{
    public class LeaveApplicationController : Controller
    {
        private LeaveApplicationService _leaveApplicationService;
        private EmployeeService _employeeService;

        public LeaveApplicationController(LeaveApplicationService leaveApplicationService, EmployeeService employeeService)
        {
            _leaveApplicationService = leaveApplicationService;
            _employeeService = employeeService;
        }

        public IActionResult Index(int? EmployeeId, DateTime? fromDate, DateTime? toDate)
        {
            var query = _leaveApplicationService.GetAll(EmployeeId, fromDate, toDate);

            ViewData["fromDate"] = fromDate;
            ViewData["toDate"] = toDate;

            ViewBag.employeelist = new SelectList(_employeeService.GetDropDown(), "Value", "Text");

            return View(query);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.employeelist = new SelectList(_employeeService.GetDropDown(), "Value", "Text");

            List<SelectListItem> leaveList = new List<SelectListItem>()
            {
                new SelectListItem { Text = "Medical Leave"},
                new SelectListItem { Text = "Maternity Leave"},
                new SelectListItem { Text = "Casual Leave"},
                new SelectListItem { Text = "Wthout Leave"},
                new SelectListItem { Text = "Earning Leave"},
            };
            ViewBag.Leave = leaveList;
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

        [HttpGet]
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

            //List<SelectListItem> leaveList = new List<SelectListItem>()
            //{
            //    new SelectListItem { Text = "Medical Leave"},
            //    new SelectListItem { Text = "Maternity Leave"},
            //    new SelectListItem { Text = "Casual Leave"},
            //    new SelectListItem { Text = "Wthout Leave"},
            //    new SelectListItem { Text = "Earning Leave"},
            //};
            //ViewBag.Leave = leaveList;

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
