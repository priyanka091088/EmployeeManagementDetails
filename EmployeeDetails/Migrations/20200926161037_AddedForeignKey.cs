using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeDetails.Migrations
{
    public partial class AddedForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_employee_department_DepartmentDepartId",
                table: "employee");

            migrationBuilder.DropIndex(
                name: "IX_employee_DepartmentDepartId",
                table: "employee");

            migrationBuilder.DropColumn(
                name: "DepartmentDepartId",
                table: "employee");

            migrationBuilder.CreateIndex(
                name: "IX_employee_DepartId",
                table: "employee",
                column: "DepartId");

            migrationBuilder.AddForeignKey(
                name: "FK_employee_department_DepartId",
                table: "employee",
                column: "DepartId",
                principalTable: "department",
                principalColumn: "DepartId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_employee_department_DepartId",
                table: "employee");

            migrationBuilder.DropIndex(
                name: "IX_employee_DepartId",
                table: "employee");

            migrationBuilder.AddColumn<int>(
                name: "DepartmentDepartId",
                table: "employee",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_employee_DepartmentDepartId",
                table: "employee",
                column: "DepartmentDepartId");

            migrationBuilder.AddForeignKey(
                name: "FK_employee_department_DepartmentDepartId",
                table: "employee",
                column: "DepartmentDepartId",
                principalTable: "department",
                principalColumn: "DepartId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
