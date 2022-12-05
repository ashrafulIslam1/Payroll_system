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

        [Display(Name = "Department Name")]
        public string? DepartmentName { get; set; }

        [Display(Name = "Present Address")]
        public string? PresentAddress { get; set; }

        [Display(Name = "Permanent Address")]
        public string? PermanentAddressBn { get; set; }

        [CurrentorGreaterDate]
        [Display(Name = "Join Date")]
        public DateTime JoinDate { get; set; }

        public string? Email { get; set; }

        [Display(Name = "Mobile Number")]
        public string? MobileNo { get; set; }


    }
}
