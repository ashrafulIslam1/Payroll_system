using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Payroll_system.Migrations
{
    public partial class addpresentabsentworkingdays : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LeaveDays",
                table: "MonthlySalary",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PresentDays",
                table: "MonthlySalary",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "WorkingDays",
                table: "MonthlySalary",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LeaveDays",
                table: "MonthlySalary");

            migrationBuilder.DropColumn(
                name: "PresentDays",
                table: "MonthlySalary");

            migrationBuilder.DropColumn(
                name: "WorkingDays",
                table: "MonthlySalary");
        }
    }
}
