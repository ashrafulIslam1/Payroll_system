using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Payroll_system.Migrations
{
    public partial class Removegrosssalry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "GrossSalary",
                table: "Salarys",
                newName: "MedicalExpense");

            migrationBuilder.AddColumn<double>(
                name: "Basic",
                table: "Salarys",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "HomeAllowance",
                table: "Salarys",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Basic",
                table: "Salarys");

            migrationBuilder.DropColumn(
                name: "HomeAllowance",
                table: "Salarys");

            migrationBuilder.RenameColumn(
                name: "MedicalExpense",
                table: "Salarys",
                newName: "GrossSalary");
        }
    }
}
