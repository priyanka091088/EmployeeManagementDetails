using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeDetails.Migrations
{
    public partial class changedtable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                newName: "emp");

            migrationBuilder.RenameTable(
                name: "departments",
                newName: "dep");

            migrationBuilder.RenameIndex(
                name: "IX_employees_departmentDepartId",
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                newName: "employees");

            migrationBuilder.RenameTable(
                name: "dep",
                newName: "departments");

            migrationBuilder.RenameIndex(
                name: "IX_emp_departmentDepartId",
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
    }
}
