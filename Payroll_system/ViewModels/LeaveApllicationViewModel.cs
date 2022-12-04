using System.ComponentModel.DataAnnotations;
using Payroll_system.Common_Daterange_Attribute;

namespace Payroll_system.ViewModels
{
    public class LeaveApllicationViewModel
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string? EmployeeName { get; set; }
        public string? LeaveType { get; set; }
        public string? ReasonOfLeave { get; set; }
        [CurrentorGreaterDate]
        public DateTime FromDate { get; set; }
        [CurrentorGreaterDate]
        public DateTime ToDate { get; set; }
        public DateTime ApplicationDate { get; set; }
        public DateTime? ApprovalDate { get; set; }
        public string? ApproavedBy { get; set; }
        
    }
}
