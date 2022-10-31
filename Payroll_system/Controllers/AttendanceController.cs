﻿using Payroll_system.ApplicationDb;
using Payroll_system.Models;
using Microsoft.AspNetCore.Mvc;
using Payroll_system.ViewModels;
using Payroll_system.Services;

namespace Payroll_system.Controllers
{
    public class AttendanceController : Controller
    {
        private AttendanceService _attendanceService;

        public AttendanceController(AttendanceService attendanceService)
        {
            _attendanceService = attendanceService;
        }

        public IActionResult Index()
        {
            return View(_attendanceService.GetAll());
        }

        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create(AttendanceViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                _attendanceService.Create(viewModel);
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }


        public IActionResult Update(int? EmployeeId) 
        {
            if (EmployeeId == null || EmployeeId == 0)
            {
                return NotFound();
            }

            var updateAttendance = _attendanceService.GetById(EmployeeId);

            if (updateAttendance == null)
            {
                return NotFound();
            }

            return View(updateAttendance);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            return View();
        }
    }
}
