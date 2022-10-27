using System.ComponentModel.DataAnnotations;

namespace Payroll_system.Models;

public class Employee
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Dept { get; set; }
}
