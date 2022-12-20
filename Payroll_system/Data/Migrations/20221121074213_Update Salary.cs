using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Payroll_system.Migrations
{
    public partial class UpdateSalary : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SalaryTypeName",
                table: "Salarys");

            migrationBuilder.AddColumn<double>(
                name: "GrossSalary",
                table: "Salarys",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "Month",
                table: "Salarys",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "TotalPay",
                table: "Salarys",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "Year",
                table: "Salarys",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GrossSalary",
                table: "Salarys");

            migrationBuilder.DropColumn(
                name: "Month",
                table: "Salarys");

            migrationBuilder.DropColumn(
                name: "TotalPay",
                table: "Salarys");

            migrationBuilder.DropColumn(
                name: "Year",
                table: "Salarys");

            migrationBuilder.AddColumn<string>(
                name: "SalaryTypeName",
                table: "Salarys",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
