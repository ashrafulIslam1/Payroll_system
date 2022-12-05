using System.ComponentModel.DataAnnotations;
using Payroll_system.Common_Daterange_Attribute;

namespace Payroll_system.ViewModels
{
    public class LeaveApllicationViewModel
    {
        public int Id { get; set; }

        public int EmployeeId { get; set; }

        [Display(Name = "Employee Name")]
        public string? EmployeeName { get; set; }

        [Display(Name = "Type of Leave")]
        public string? LeaveType { get; set; }

        [Display(Name = "Reason Of Leave")]
        public string? ReasonOfLeave { get; set; }

        [CurrentorGreaterDate]
        public DateTime FromDate { get; set; }

        [CurrentorGreaterDate]
        public DateTime ToDate { get; set; }

        public DateTime ApplicationDate { get; set; }

        public DateTime? ApprovalDate { get; set; }

        [Display(Name = "Approaved By")]
        public string? ApproavedBy { get; set; }
        
    }
}
