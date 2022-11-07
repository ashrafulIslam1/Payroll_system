using System.ComponentModel.DataAnnotations;

namespace Payroll_system.Models;

public class Employee
{
    [Key]
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Dept { get; set; }
    public string? PresentAddress { get; set; }  
    public string? PermanentAddressBn { get; set; }
    public DateTime JoinDate { get; set; }
    public string? Email { get; set; }
    public string? MobileNo { get; set; }
    
}
