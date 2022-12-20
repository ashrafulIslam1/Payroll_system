using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Payroll_system.Migrations
{
    public partial class Tablenamechange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Salarys");

            migrationBuilder.DropColumn(
                name: "Month",
                table: "SalarySetup");

            migrationBuilder.DropColumn(
                name: "TotalPay",
                table: "SalarySetup");

            migrationBuilder.DropColumn(
                name: "Year",
                table: "SalarySetup");

            migrationBuilder.CreateTable(
                name: "MonthlySalary",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: true),
                    Month = table.Column<int>(type: "int", nullable: true),
                    Basic = table.Column<double>(type: "float", nullable: false),
                    HomeAllowance = table.Column<double>(type: "float", nullable: false),
                    MedicalExpense = table.Column<double>(type: "float", nullable: false),
                    TotalPay = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonthlySalary", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MonthlySalary");

            migrationBuilder.AddColumn<int>(
                name: "Month",
                table: "SalarySetup",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "TotalPay",
                table: "SalarySetup",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "Year",
                table: "SalarySetup",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Salarys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Basic = table.Column<double>(type: "float", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    HomeAllowance = table.Column<double>(type: "float", nullable: false),
                    MedicalExpense = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salarys", x => x.Id);
                });
        }
    }
}
