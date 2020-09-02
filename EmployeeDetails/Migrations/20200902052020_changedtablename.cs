using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeDetails.Migrations
{
    public partial class changedtablename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_employee_department_departmentDepartId",
                table: "employee");

            migrationBuilder.DropPrimaryKey(
                name: "PK_employee",
                table: "employee");

            migrationBuilder.DropPrimaryKey(
                name: "PK_department",
                table: "department");

            migrationBuilder.RenameTable(
                name: "employee",
                newName: "employees");

            migrationBuilder.RenameTable(
                name: "department",
                newName: "departments");

            migrationBuilder.RenameIndex(
                name: "IX_employee_departmentDepartId",
                table: "employees",
                newName: "IX_employees_departmentDepartId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_employees",
                table: "employees",
                column: "Eid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_departments",
                table: "departments",
                column: "DepartId");

            migrationBuilder.AddForeignKey(
                name: "FK_employees_departments_departmentDepartId",
                table: "employees",
                column: "departmentDepartId",
                principalTable: "departments",
                principalColumn: "DepartId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_employees_departments_departmentDepartId",
                table: "employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_employees",
                table: "employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_departments",
                table: "departments");

            migrationBuilder.RenameTable(
                name: "employees",
                newName: "employee");

            migrationBuilder.RenameTable(
                name: "departments",
                newName: "department");

            migrationBuilder.RenameIndex(
                name: "IX_employees_departmentDepartId",
                table: "employee",
                newName: "IX_employee_departmentDepartId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_employee",
                table: "employee",
                column: "Eid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_department",
                table: "department",
                column: "DepartId");

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
