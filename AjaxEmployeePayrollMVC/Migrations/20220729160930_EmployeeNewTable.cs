using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AjaxEmployeePayrollMVC.Migrations
{
    public partial class EmployeeNewTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Profile_Image",
                table: "Employee",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Salary",
                table: "Employee",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "Employee",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Profile_Image",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "Salary",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Employee");
        }
    }
}
