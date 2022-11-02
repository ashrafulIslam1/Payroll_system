using Payroll_system.ApplicationDb;
using Payroll_system.Models;
using Payroll_system.ViewModels;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Mvc;

namespace Payroll_system.Services;

public class SalaryService
{
    // here I initialize an object (_dbContext) where I store all the data from database table.
    private readonly ApplicationDbContext _dbContext;

	public SalaryService(ApplicationDbContext dbContext)
	{
		_dbContext = dbContext;	
	}

	public void Create(SalaryViewModel viewModel)
	{
		var model = new Salary // here this 'Salary' is the main model.
        {
            // Here I assign the viewModel properties to the model properties
            Id = viewModel.Id,
			EmployeeId = viewModel.EmployeeId,
			SalaryTypeName = viewModel.SalaryTypeName,
		};

		_dbContext.Salarys.Add(model); // Here 'Salarys' is the table name
        _dbContext.SaveChanges();
	}

	public void Update(SalaryViewModel viewModel)
	{
		var model = _dbContext.Salarys.Find(viewModel.Id);

		if (model == null)
			throw new Exception();

		model.Id = viewModel.Id;
		model.EmployeeId = viewModel.EmployeeId;
		model.SalaryTypeName = viewModel.SalaryTypeName;

		_dbContext.Salarys.Update(model);
		_dbContext.SaveChanges();
	}

	public void Delete(int id)
	{
		var model = _dbContext.Salarys.Find(id);

        if (model == null)
            throw new Exception();

		_dbContext.Salarys.Remove(model);
		_dbContext.SaveChanges();
    }

	public List<SalaryViewModel> GetAll()
	{
		var data = (from s in _dbContext.Salarys
					select new SalaryViewModel
					{
						Id = s.Id,
						SalaryTypeName = s.SalaryTypeName,
						EmployeeId = s.EmployeeId,
					}).ToList();
		return data;
	}

    public SalaryViewModel? GetById(int id)
    {
        var data = (from s in _dbContext.Salarys
					where s.Id == id
                    select new SalaryViewModel
                    {
                        Id = s.Id,
                        SalaryTypeName = s.SalaryTypeName,
                        EmployeeId = s.EmployeeId,
                    }).SingleOrDefault();
        return data;
    }
}
