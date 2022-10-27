using Microsoft.EntityFrameworkCore;
using Payroll_system.Models;

namespace Payroll_system.ApplicationDb
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<LeaveApplication> LeaveApplications { get; set; }
        public DbSet<Salary> Salarys { get; set; }
        public DbSet<Department> Departments { get; set; }
    }
}
