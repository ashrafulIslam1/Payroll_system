using Payroll_system.ApplicationDb;
using Payroll_system.Models;
using Microsoft.AspNetCore.Mvc;
using Payroll_system.ViewModels;
using Payroll_system.Services;
using Microsoft.AspNetCore.Mvc.Rendering;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Payroll_system.Controllers
{
    public class MonthlySalaryController : Controller
    {
        private MonthlySalaryService _monthlysalaryService;
        private EmployeeService _employeeService;

        public MonthlySalaryController(MonthlySalaryService monthlysalaryService, EmployeeService employeeService)
        {
            _monthlysalaryService = monthlysalaryService;
            _employeeService = employeeService;
        }
        public IActionResult Index(int? employeeId, DateTime? monthYear)
        {
            int? _month = monthYear == null ? null : monthYear.Value.Month;
            int? _year = monthYear == null ? null : monthYear.Value.Year;

            var query = _monthlysalaryService.GetAll(employeeId, _month, _year);

            ViewBag.employeelist = new SelectList(_employeeService.GetDropDown(), "Value", "Text");
            return View(query);
        }

        [HttpGet]
        public IActionResult Genarate()
        {
            ViewBag.employeelist = new SelectList(_employeeService.GetDropDown(), "Value", "Text");
            return View();
        }

        [HttpPost]
        public IActionResult Genarate(int year, int month)
        {
            if (ModelState.IsValid)
            {
                _monthlysalaryService.Genarate(year, month);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
            //return View(viewModel);
        }
    }
}
