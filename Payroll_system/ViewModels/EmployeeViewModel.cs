using System.ComponentModel.DataAnnotations;
using Payroll_system.Common_Daterange_Attribute;

namespace Payroll_system.ViewModels
{
    public class EmployeeViewModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int DepartmentId { get; set; }
        public string? DepartmentName { get; set; }
        public string? PresentAddress { get; set; }
        public string? PermanentAddressBn { get; set; }
        [CurrentorGreaterDate]
        public DateTime JoinDate { get; set; }
        public string? Email { get; set; }
        public string? MobileNo { get; set; }


    }
}
