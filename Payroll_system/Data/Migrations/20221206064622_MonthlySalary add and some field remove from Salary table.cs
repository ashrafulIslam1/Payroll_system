using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Payroll_system.Migrations
{
    public partial class MonthlySalaryaddandsomefieldremovefromSalarytable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Month",
                table: "Salarys");

            migrationBuilder.DropColumn(
                name: "TotalPay",
                table: "Salarys");

            migrationBuilder.DropColumn(
                name: "Year",
                table: "Salarys");

            migrationBuilder.CreateTable(
                name: "SalarySetup",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Month = table.Column<int>(type: "int", nullable: false),
                    Basic = table.Column<double>(type: "float", nullable: false),
                    HomeAllowance = table.Column<double>(type: "float", nullable: false),
                    MedicalExpense = table.Column<double>(type: "float", nullable: false),
                    TotalPay = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalarySetup", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SalarySetup");

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
    }
}
