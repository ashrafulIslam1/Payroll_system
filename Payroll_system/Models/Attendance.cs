namespace Payroll_system.Models;

public class Attendance
{
    public int AttendanceId { get; set; }
    public int EmployeeId { get; set; }
    public string EmployeeName { get; set; }
    public DateTime InDateTime { get; set; }
    public DateTime OutDateTime { get; set; }
    public DateTime Date { get; set; }
}
