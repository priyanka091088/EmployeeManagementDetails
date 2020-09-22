using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeDetails.Migrations
{
    public partial class twotablesadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "roleId",
                table: "employee",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "userId",
                table: "employee",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(nullable: true),
                    IsRead = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "UserNotifications",
                columns: table => new
                {
                    NotificationId = table.Column<int>(nullable: false),
                    ApplicationUserId = table.Column<string>(nullable: false),
                    EmployeeEid = table.Column<int>(nullable: true),
                    DepartmentDepartId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserNotifications", x => new { x.NotificationId, x.ApplicationUserId });
                    table.ForeignKey(
                        name: "FK_UserNotifications_department_DepartmentDepartId",
                        column: x => x.DepartmentDepartId,
                        principalTable: "department",
                        principalColumn: "DepartId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserNotifications_employee_EmployeeEid",
                        column: x => x.EmployeeEid,
                        principalTable: "employee",
                        principalColumn: "Eid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserNotifications_Notifications_NotificationId",
                        column: x => x.NotificationId,
                        principalTable: "Notifications",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserNotifications_DepartmentDepartId",
                table: "UserNotifications",
                column: "DepartmentDepartId");

            migrationBuilder.CreateIndex(
                name: "IX_UserNotifications_EmployeeEid",
                table: "UserNotifications",
                column: "EmployeeEid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserNotifications");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropColumn(
                name: "roleId",
                table: "employee");

            migrationBuilder.DropColumn(
                name: "userId",
                table: "employee");
        }
    }
}
