using Payroll_system.ApplicationDb;
using Payroll_system.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Payroll_system.Models;
using System;
using System.Xml.Linq;

namespace Payroll_system.Services;

public class EmployeeService
{
    // here I initialize an object (_dbContext) where I store all the data from database table.
    private readonly ApplicationDbContext _dbContext;

    public EmployeeService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Create(EmployeeViewModel viewModel)
    {
        var model = new Employee // here this 'Employee' is the main model.
        {
            // Here I assign the viewModel properties to the model properties
            Name = viewModel.Name,
            Id = viewModel.Id,
            Dept = viewModel.Dept,
            PresentAddress = viewModel.PresentAddress,
            PermanentAddressBn = viewModel.PermanentAddressBn,
            JoinDate = viewModel.JoinDate,
            Email = viewModel.Email,
            MobileNo = viewModel.MobileNo,
        };
        _dbContext.Employees.Add(model); // Here 'Employees' is the table name
        _dbContext.SaveChanges();
    }

    public void Update(EmployeeViewModel viewModel)
    {
        var model = _dbContext.Employees.Find(viewModel.Id);

        if (model == null)
            throw new Exception();

        model.Name = viewModel.Name;
        model.Id = viewModel.Id;
        model.Dept = viewModel.Dept;
        model.PresentAddress = viewModel.PresentAddress;
        model.JoinDate = viewModel.JoinDate;
        model.PresentAddress = viewModel.PresentAddress;
        model.PermanentAddressBn = viewModel.PermanentAddressBn;
        model.MobileNo = viewModel.MobileNo;
        model.Email = viewModel.Email;

        _dbContext.Employees.Update(model);
        _dbContext.SaveChanges();
    }

    public void Delete(int id)
    {
        var model = _dbContext.Employees.Find(id);

        if (model == null)
            throw new Exception();

        _dbContext.Employees.Remove(model);
        _dbContext.SaveChanges();
    }

    public List<EmployeeViewModel> GetAll()
    {
        var data = (from s in _dbContext.Employees
                   select new EmployeeViewModel
                   {
                       Name=s.Name,
                       Dept=s.Dept,
                       Id=s.Id,
                       MobileNo=s.MobileNo,
                       PermanentAddressBn=s.PermanentAddressBn,
                       PresentAddress=s.PresentAddress,
                       Email=s.Email,
                       JoinDate=s.JoinDate
                   }).ToList();
        return data;
    }

    public EmployeeViewModel? GetById(int id)
    {
        var data = (from s in _dbContext.Employees
                    where s.Id == id
                    select new EmployeeViewModel
                    {
                        Name = s.Name,
                        Dept = s.Dept,
                        Id = s.Id,
                        MobileNo = s.MobileNo,
                        PermanentAddressBn = s.PermanentAddressBn,
                        PresentAddress = s.PresentAddress,
                        Email = s.Email,
                        JoinDate = s.JoinDate
                    }).SingleOrDefault();
        return data;
    }
    //public EmployeeViewModel? GetByName(string Name)
    //{
    //    var data = (from s in _dbContext.Employees
    //                where s.Name == Name
    //                select new EmployeeViewModel
    //                {
    //                    Name = s.Name,
    //                    Dept = s.Dept,
    //                    Id = s.Id,
    //                    MobileNo = s.MobileNo,
    //                    PermanentAddressBn = s.PermanentAddressBn,
    //                    PresentAddress = s.PresentAddress,
    //                    Email = s.Email,
    //                    JoinDate = s.JoinDate
    //                }).SingleOrDefault();
    //    return data;
    //}

    public List<DropDownViewModel> GetDropDown()
    {
        var data = (from s in _dbContext.Employees
                    select new DropDownViewModel
                    {
                        Value = s.Id,
                        Text = s.Name
                    }).ToList();
        return data;
    }
}
