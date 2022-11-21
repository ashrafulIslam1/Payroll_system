namespace Payroll_system.ViewModels
{
    public class SalaryViewModel
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string? EmployeeName { get; set; }
        public double GrossSalary { get; set; }
        public double TotalPay { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }

        //public string? SalaryTypeName { get; set; }
    }
}
