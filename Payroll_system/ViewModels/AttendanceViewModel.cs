using Payroll_system.Common_Daterange_Attribute;

namespace Payroll_system.ViewModels
{
    public class AttendanceViewModel
    {
        public int AttendanceId { get; set; }
        public int EmployeeId { get; set; }
        public string? EmployeeName { get; set; }
        public DateTime InTime { get; set; }
        public DateTime OutTime { get; set; }

        [CurrentDate]
        public DateTime Date { get; set; }
        public int Status { get; set; }
    }
}
