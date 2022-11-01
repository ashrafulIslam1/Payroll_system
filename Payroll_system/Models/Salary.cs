using System.ComponentModel.DataAnnotations;

namespace Payroll_system.Models;

public class Salary
{
    [Key]
    public int Id { get; set; }
    public string? SalaryTypeName { get; set; }
    public int EmployeeId { get; set; }
}
