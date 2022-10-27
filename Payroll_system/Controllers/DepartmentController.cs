using Payroll_system.ApplicationDb;
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
            if(viewModel.Id == 0)
                _departmentService.Create(viewModel);
            else
                _departmentService.Update(viewModel);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _departmentService.Delete(id);

            return RedirectToAction("Index");
        }
    }
}
