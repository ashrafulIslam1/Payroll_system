using System.ComponentModel.DataAnnotations;

namespace Payroll_system.Models;

public class Salary
{
    [Key]
    public int Id { get; set; }
    public int EmployeeId { get; set; }
    public double GrossSalary { get; set; }
    public double TotalPay { get; set; }
    public int Year { get; set; }
    public int Month { get; set; }

    //public string? SalaryTypeName { get; set; }
}
