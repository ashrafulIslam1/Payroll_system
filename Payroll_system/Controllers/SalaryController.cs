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

        public IActionResult Update(int id)
        {
            if (id == 0)
                return NotFound();

            var updateSalary = _salaryService.GetById(id);

            if (updateSalary == null)
            {
                return NotFound();
            }
            return View(updateSalary);
        }

        [HttpPost]
        public IActionResult Update(SalaryViewModel viewModel)
        {
            if(ModelState.IsValid)
            {
                _salaryService.Update(viewModel);
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }

        public IActionResult Delete(int id)
        {
            //if(id is 0 or null)

            if(id == 0)
            {
                return NotFound();
            }

            var deleteSalary = _salaryService.GetById(id);

            if(deleteSalary == null)
            {
                return NotFound();
            }

            return View(deleteSalary);
        }

        [HttpPost]
        public IActionResult DeleteALL(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            _salaryService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
