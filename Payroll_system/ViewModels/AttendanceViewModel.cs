namespace Payroll_system.ViewModels
{
    public class AttendanceViewModel
    {
        public int AttendanceId { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public DateTime InDateTime { get; set; }
        public DateTime OutDateTime { get; set; }
        public DateTime Date { get; set; }
        public int Status { get; set; }
    }
}
