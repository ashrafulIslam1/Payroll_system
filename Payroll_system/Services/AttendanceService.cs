using Payroll_system.ApplicationDb;
using Payroll_system.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Payroll_system.Models;
using System;

namespace Payroll_system.Services;

public class AttendanceService
{
    // here I initialize an object (_dbContext) where I store all the data from database table.
    private readonly ApplicationDbContext _dbContext;

    public AttendanceService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Create(AttendanceViewModel viewModel)
    {
        var model = new Attendance // here this 'Attendance' is the main model.
        {
            // Here I assign the viewModel properties to model properties
            AttendanceId = viewModel.AttendanceId,
            EmployeeId = viewModel.EmployeeId,
            EmployeeName = viewModel.EmployeeName,
            Date = viewModel.Date,
            InDateTime = viewModel.InDateTime,
            OutDateTime = viewModel.OutDateTime,
        };
        
        _dbContext.Attendances.Add(model); // Here 'Attendancse' is the table name
        _dbContext.SaveChanges();
    }

    public void Update(AttendanceViewModel viewModel)
    {
        var model = _dbContext.Attendances.Find(viewModel.AttendanceId);

        if (model == null)
            throw new Exception();

        model.AttendanceId = viewModel.AttendanceId;
        model.EmployeeId = viewModel.EmployeeId;
        model.EmployeeName = viewModel.EmployeeName;
        model.InDateTime = viewModel.InDateTime;
        model.OutDateTime = viewModel.OutDateTime;

        _dbContext.Attendances.Update(model);
        _dbContext.SaveChanges();
    }

    public void Delete(int id)
    {
        var model = _dbContext.Attendances.Find(id);
        if (model == null)
            throw new Exception();

        _dbContext.Attendances.Remove(model);
        _dbContext.SaveChanges();
    }

    public List<AttendanceViewModel> GetAll()
    {
        var data = (from s in _dbContext.Attendances
                    select new AttendanceViewModel
                    {
                        AttendanceId = s.AttendanceId,
                        EmployeeId = s.EmployeeId,
                        EmployeeName = s.EmployeeName,
                        Date = s.Date,
                        InDateTime = s.InDateTime,
                        OutDateTime = s.OutDateTime,
                        Status = s.InDateTime == DateTime.MinValue || s.OutDateTime == DateTime.MinValue ? 0 : 1
                    }).ToList();

        // data.Where(x => x.Status == 1).Count();
        return data;
    }

    public AttendanceViewModel? GetById(int id)
    {
        var data = (from s in _dbContext.Attendances
                    where s.AttendanceId == id
                    select new AttendanceViewModel
                    {
                        AttendanceId = s.AttendanceId,
                        EmployeeId = s.EmployeeId,
                        EmployeeName = s.EmployeeName,
                        Date = s.Date,
                        InDateTime = s.InDateTime,
                        OutDateTime = s.OutDateTime,
                    }).SingleOrDefault();
        return data;
    }
}
