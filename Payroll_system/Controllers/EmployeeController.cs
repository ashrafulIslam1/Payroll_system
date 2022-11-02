using Payroll_system.ApplicationDb;
using Payroll_system.Models;
using Microsoft.AspNetCore.Mvc;
using Payroll_system.ViewModels;
using Payroll_system.Services;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Payroll_system.Controllers
{
    public class EmployeeController : Controller
    {
        private EmployeeService _employeeService;
        private DepartmentService _departmentService;
        public EmployeeController(EmployeeService employeeService, DepartmentService departmentService)
        {
            _employeeService = employeeService;
            _departmentService = departmentService;
        }

        public IActionResult Index()
        {
            return View(_employeeService.GetAll());
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.departmentlist = new SelectList(_departmentService.GetDropDown(), "Valu", "Text");
            return View();
        }

        [HttpPost]
        public IActionResult Create(EmployeeViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                _employeeService.Create(viewModel);
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Update(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var updateEmployee = _employeeService.GetById((int)id);

            if (updateEmployee == null)
            {
                return NotFound();
            }

            return View(updateEmployee);
        }

        [HttpPost]
        public IActionResult Update(EmployeeViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                _employeeService.Update(viewModel);
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }

        public IActionResult Delete(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }

            var deleteEmployee = _employeeService.GetById((int)id);

            if(deleteEmployee == null)
            {
                return NotFound();
            }

            return View(deleteEmployee);
        }

        [HttpPost]
        public IActionResult DeleteAll(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            _employeeService.Delete((int)id);

            return RedirectToAction("Index");
        }
    }
}
