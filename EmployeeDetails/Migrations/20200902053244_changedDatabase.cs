using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeDetails.Migrations
{
    public partial class changedDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_emp_dep_departmentDepartId",
                table: "emp");

            migrationBuilder.DropPrimaryKey(
                name: "PK_emp",
                table: "emp");

            migrationBuilder.DropPrimaryKey(
                name: "PK_dep",
                table: "dep");

            migrationBuilder.RenameTable(
                name: "emp",
                newName: "employee");

            migrationBuilder.RenameTable(
                name: "dep",
                newName: "department");

            migrationBuilder.RenameIndex(
                name: "IX_emp_departmentDepartId",
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                newName: "emp");

            migrationBuilder.RenameTable(
                name: "department",
                newName: "dep");

            migrationBuilder.RenameIndex(
                name: "IX_employee_departmentDepartId",
                table: "emp",
                newName: "IX_emp_departmentDepartId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_emp",
                table: "emp",
                column: "Eid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_dep",
                table: "dep",
                column: "DepartId");

            migrationBuilder.AddForeignKey(
                name: "FK_emp_dep_departmentDepartId",
                table: "emp",
                column: "departmentDepartId",
                principalTable: "dep",
                principalColumn: "DepartId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
