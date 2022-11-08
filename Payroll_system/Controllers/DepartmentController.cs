﻿using Payroll_system.ApplicationDb;
using Payroll_system.Models;
using Microsoft.AspNetCore.Mvc;
using Payroll_system.ViewModels;
using Payroll_system.Services;

namespace Payroll_system.Controllers
{
    public class DepartmentController : Controller
    {
        private DepartmentService _departmentService;

        public DepartmentController(DepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        public IActionResult Index(string searchString)
        {
            return View(_departmentService.GetAll());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(DepartmentViewModel viewModel)
        {
            if(ModelState.IsValid)
            {
                _departmentService.Create(viewModel);
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

            var updateDept = _departmentService.GetById(id);

            if(updateDept == null)
            {
                return NotFound();
            }
            return View(updateDept);
        }

        [HttpPost]
        public IActionResult Update(DepartmentViewModel viewModel)
        {
            if(ModelState.IsValid)
            {
                _departmentService.Update(viewModel);
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var deleteDepartment = _departmentService.GetById((int)id);

            if (deleteDepartment == null)
            {
                return NotFound();
            }

            return View(deleteDepartment);
        }

        [HttpPost]
        public IActionResult DeleteAll(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            _departmentService.Delete((int)id);

            return RedirectToAction("Index"); ;
        }
    }
}
