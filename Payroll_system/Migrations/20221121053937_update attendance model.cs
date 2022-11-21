using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Payroll_system.Migrations
{
    public partial class updateattendancemodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OutDateTime",
                table: "Attendances",
                newName: "OutTime");

            migrationBuilder.RenameColumn(
                name: "InDateTime",
                table: "Attendances",
                newName: "InTime");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OutTime",
                table: "Attendances",
                newName: "OutDateTime");

            migrationBuilder.RenameColumn(
                name: "InTime",
                table: "Attendances",
                newName: "InDateTime");
        }
    }
}
