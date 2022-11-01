using Payroll_system.ApplicationDb;
using Payroll_system.Models;
using Microsoft.AspNetCore.Mvc;
using Payroll_system.ViewModels;
using Payroll_system.Services;

namespace Payroll_system.Controllers
{
    public class SalaryController : Controller
    {
        private SalaryService _salaryService;

        public SalaryController(SalaryService salaryService)
        {
            _salaryService = salaryService;
        }
        public IActionResult Index(string searchString)
        {
            return View(_salaryService.GetAll());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(SalaryViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                _salaryService.Create(viewModel);
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            return View();
        }
    }
}
