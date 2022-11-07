﻿using Payroll_system.ApplicationDb;
using Payroll_system.Models;
using Microsoft.AspNetCore.Mvc;
using Payroll_system.ViewModels;
using Payroll_system.Services;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Payroll_system.Controllers
{
    public class AttendanceController : Controller
    {
        private AttendanceService _attendanceService;
        private EmployeeService _employeeService;

        public AttendanceController(AttendanceService attendanceService, EmployeeService employeeService)
        {
            _attendanceService = attendanceService;
            _employeeService = employeeService; 
        }

        public IActionResult Index()
        {
            return View(_attendanceService.GetAll());
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.employeelist = new SelectList(_employeeService.GetDropDown(), "Value", "Text");
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


        public IActionResult Update(int? id) 
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var updateAttendance = _attendanceService.GetById((int)id);

            if (updateAttendance == null)
            {
                return NotFound();
            }

            return View(updateAttendance);
        }

        [HttpPost]
        public IActionResult Update(AttendanceViewModel viewModel)
        {
            if(ModelState.IsValid)
            {
                _attendanceService.Update(viewModel);
                return RedirectToAction("Index");
            }
            return View(viewModel) ;
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var deleteAttendance = _attendanceService.GetById((int)id);

            if(deleteAttendance == null)
                return NotFound();

            return View(deleteAttendance);
        }

        [HttpPost]
        public IActionResult DeleteAll(int? id)
        {
            if(id == null || id ==0)
            {
                return NotFound();
            }
            _attendanceService.Delete((int)id);

            return RedirectToAction("Index");
        }
    }
}
