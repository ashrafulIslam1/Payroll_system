﻿using Payroll_system.ApplicationDb;
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
            //EmployeeId = viewModel.EmployeeId,
            //EmployeeName = viewModel.EmployeeName,
            Date = viewModel.Date,
            InTime = viewModel.InTime,
            OutTime = viewModel.OutTime,
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
        //model.EmployeeName = viewModel.EmployeeName;
        model.InTime = viewModel.InTime;
        model.OutTime = viewModel.OutTime;

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

    public List<AttendanceViewModel> GetAll(int? EmployeeId, DateTime? fromDate, DateTime? toDate)
    {         
        var query = (from s in _dbContext.Attendances
                     join e in _dbContext.Employees on s.EmployeeId equals e.Id
                     select new AttendanceViewModel
                     {
                        AttendanceId = s.AttendanceId,
                        EmployeeId = s.EmployeeId,
                        EmployeeName = e.Name,
                        Date = s.Date,
                        InTime = s.InTime,
                        OutTime = s.OutTime,
                        Status = s.InTime == DateTime.MinValue || s.OutTime == DateTime.MinValue ? 0 : 1
                        // query.Where(x => x.Status == 1).Count();
                     }).AsQueryable();

        if (EmployeeId != null)
        {
            query = query.Where(s => s.EmployeeId == (EmployeeId));
        }
        if (fromDate.HasValue && toDate.HasValue)
        {
            query = query.Where(s => s.Date >= fromDate && s.Date <= toDate);
        }
        return query.ToList();
    }

    public AttendanceViewModel? GetById(int id)
    {
        var data = (from s in _dbContext.Attendances
                    where s.AttendanceId == id
                    select new AttendanceViewModel
                    {
                        AttendanceId = s.AttendanceId,
                        EmployeeId = s.EmployeeId,
                        //EmployeeName = s.EmployeeName,
                        Date = s.Date,
                        InTime = s.InTime,
                        OutTime = s.OutTime,
                    }).SingleOrDefault();
        return data;
    }
}
