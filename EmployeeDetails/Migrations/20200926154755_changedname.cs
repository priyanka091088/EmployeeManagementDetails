using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeDetails.Migrations
{
    public partial class changedname : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_employee_department_departmentDepartId",
                table: "employee");

            migrationBuilder.RenameColumn(
                name: "departmentDepartId",
                table: "employee",
                newName: "DepartmentDepartId");

            migrationBuilder.RenameIndex(
                name: "IX_employee_departmentDepartId",
                table: "employee",
                newName: "IX_employee_DepartmentDepartId");

            migrationBuilder.AddForeignKey(
                name: "FK_employee_department_DepartmentDepartId",
                table: "employee",
                column: "DepartmentDepartId",
                principalTable: "department",
                principalColumn: "DepartId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_employee_department_DepartmentDepartId",
                table: "employee");

            migrationBuilder.RenameColumn(
                name: "DepartmentDepartId",
                table: "employee",
                newName: "departmentDepartId");

            migrationBuilder.RenameIndex(
                name: "IX_employee_DepartmentDepartId",
                table: "employee",
                newName: "IX_employee_departmentDepartId");

            migrationBuilder.AddForeignKey(
                name: "FK_employee_department_departmentDepartId",
                table: "employee",
                column: "departmentDepartId",
                principalTable: "department",
                principalColumn: "DepartId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
