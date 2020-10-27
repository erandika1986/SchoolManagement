using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolManagement.Data.Migrations
{
    public partial class SMMS000003 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "TimeTable");

            migrationBuilder.RenameTable(
                name: "ClassTimeTablePeriodAssignTeacher",
                schema: "Master",
                newName: "ClassTimeTablePeriodAssignTeacher",
                newSchema: "TimeTable");

            migrationBuilder.RenameTable(
                name: "ClassTimeTablePeriod",
                schema: "Master",
                newName: "ClassTimeTablePeriod",
                newSchema: "TimeTable");

            migrationBuilder.AddColumn<long>(
                name: "TimeTableId",
                schema: "TimeTable",
                table: "ClassTimeTablePeriod",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "TimeTable",
                schema: "TimeTable",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    AcademicYearId = table.Column<long>(nullable: false),
                    IsPublished = table.Column<bool>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatedById = table.Column<long>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedById = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TimeTable_AcademicYear_AcademicYearId",
                        column: x => x.AcademicYearId,
                        principalSchema: "Master",
                        principalTable: "AcademicYear",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TimeTable_User_CreatedById",
                        column: x => x.CreatedById,
                        principalSchema: "Account",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TimeTable_User_UpdatedById",
                        column: x => x.UpdatedById,
                        principalSchema: "Account",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "Role",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2020, 8, 8, 3, 48, 37, 794, DateTimeKind.Utc).AddTicks(8658), new DateTime(2020, 8, 8, 3, 48, 37, 795, DateTimeKind.Utc).AddTicks(476) });

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "Role",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2020, 8, 8, 3, 48, 37, 795, DateTimeKind.Utc).AddTicks(4753), new DateTime(2020, 8, 8, 3, 48, 37, 795, DateTimeKind.Utc).AddTicks(4788) });

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "Role",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2020, 8, 8, 3, 48, 37, 795, DateTimeKind.Utc).AddTicks(4888), new DateTime(2020, 8, 8, 3, 48, 37, 795, DateTimeKind.Utc).AddTicks(4888) });

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "Role",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2020, 8, 8, 3, 48, 37, 795, DateTimeKind.Utc).AddTicks(4890), new DateTime(2020, 8, 8, 3, 48, 37, 795, DateTimeKind.Utc).AddTicks(4890) });

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "Role",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2020, 8, 8, 3, 48, 37, 795, DateTimeKind.Utc).AddTicks(4891), new DateTime(2020, 8, 8, 3, 48, 37, 795, DateTimeKind.Utc).AddTicks(4892) });

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "Role",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2020, 8, 8, 3, 48, 37, 795, DateTimeKind.Utc).AddTicks(4892), new DateTime(2020, 8, 8, 3, 48, 37, 795, DateTimeKind.Utc).AddTicks(4895) });

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "Role",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2020, 8, 8, 3, 48, 37, 795, DateTimeKind.Utc).AddTicks(4896), new DateTime(2020, 8, 8, 3, 48, 37, 795, DateTimeKind.Utc).AddTicks(4897) });

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "Role",
                keyColumn: "Id",
                keyValue: 8L,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2020, 8, 8, 3, 48, 37, 795, DateTimeKind.Utc).AddTicks(4899), new DateTime(2020, 8, 8, 3, 48, 37, 795, DateTimeKind.Utc).AddTicks(4900) });

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "User",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2020, 8, 8, 3, 48, 37, 777, DateTimeKind.Utc).AddTicks(6845), new DateTime(2020, 8, 8, 3, 48, 37, 777, DateTimeKind.Utc).AddTicks(8001) });

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "User",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2020, 8, 8, 3, 48, 37, 778, DateTimeKind.Utc).AddTicks(1013), new DateTime(2020, 8, 8, 3, 48, 37, 778, DateTimeKind.Utc).AddTicks(1035) });

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "UserRole",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { 1L, 1L },
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2020, 8, 8, 3, 48, 37, 829, DateTimeKind.Utc).AddTicks(561), new DateTime(2020, 8, 8, 3, 48, 37, 829, DateTimeKind.Utc).AddTicks(1792) });

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "UserRole",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { 2L, 2L },
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2020, 8, 8, 3, 48, 37, 829, DateTimeKind.Utc).AddTicks(6677), new DateTime(2020, 8, 8, 3, 48, 37, 829, DateTimeKind.Utc).AddTicks(6693) });

            migrationBuilder.CreateIndex(
                name: "IX_ClassTimeTablePeriod_TimeTableId",
                schema: "TimeTable",
                table: "ClassTimeTablePeriod",
                column: "TimeTableId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeTable_AcademicYearId",
                schema: "TimeTable",
                table: "TimeTable",
                column: "AcademicYearId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeTable_CreatedById",
                schema: "TimeTable",
                table: "TimeTable",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_TimeTable_UpdatedById",
                schema: "TimeTable",
                table: "TimeTable",
                column: "UpdatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_ClassTimeTablePeriod_TimeTable_TimeTableId",
                schema: "TimeTable",
                table: "ClassTimeTablePeriod",
                column: "TimeTableId",
                principalSchema: "TimeTable",
                principalTable: "TimeTable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClassTimeTablePeriod_TimeTable_TimeTableId",
                schema: "TimeTable",
                table: "ClassTimeTablePeriod");

            migrationBuilder.DropTable(
                name: "TimeTable",
                schema: "TimeTable");

            migrationBuilder.DropIndex(
                name: "IX_ClassTimeTablePeriod_TimeTableId",
                schema: "TimeTable",
                table: "ClassTimeTablePeriod");

            migrationBuilder.DropColumn(
                name: "TimeTableId",
                schema: "TimeTable",
                table: "ClassTimeTablePeriod");

            migrationBuilder.RenameTable(
                name: "ClassTimeTablePeriodAssignTeacher",
                schema: "TimeTable",
                newName: "ClassTimeTablePeriodAssignTeacher",
                newSchema: "Master");

            migrationBuilder.RenameTable(
                name: "ClassTimeTablePeriod",
                schema: "TimeTable",
                newName: "ClassTimeTablePeriod",
                newSchema: "Master");

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "Role",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2020, 7, 11, 9, 48, 49, 256, DateTimeKind.Utc).AddTicks(8896), new DateTime(2020, 7, 11, 9, 48, 49, 257, DateTimeKind.Utc).AddTicks(659) });

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "Role",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2020, 7, 11, 9, 48, 49, 257, DateTimeKind.Utc).AddTicks(3620), new DateTime(2020, 7, 11, 9, 48, 49, 257, DateTimeKind.Utc).AddTicks(3638) });

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "Role",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2020, 7, 11, 9, 48, 49, 257, DateTimeKind.Utc).AddTicks(3692), new DateTime(2020, 7, 11, 9, 48, 49, 257, DateTimeKind.Utc).AddTicks(3693) });

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "Role",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2020, 7, 11, 9, 48, 49, 257, DateTimeKind.Utc).AddTicks(3694), new DateTime(2020, 7, 11, 9, 48, 49, 257, DateTimeKind.Utc).AddTicks(3695) });

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "Role",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2020, 7, 11, 9, 48, 49, 257, DateTimeKind.Utc).AddTicks(3695), new DateTime(2020, 7, 11, 9, 48, 49, 257, DateTimeKind.Utc).AddTicks(3696) });

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "Role",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2020, 7, 11, 9, 48, 49, 257, DateTimeKind.Utc).AddTicks(3697), new DateTime(2020, 7, 11, 9, 48, 49, 257, DateTimeKind.Utc).AddTicks(3697) });

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "Role",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2020, 7, 11, 9, 48, 49, 257, DateTimeKind.Utc).AddTicks(3698), new DateTime(2020, 7, 11, 9, 48, 49, 257, DateTimeKind.Utc).AddTicks(3698) });

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "Role",
                keyColumn: "Id",
                keyValue: 8L,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2020, 7, 11, 9, 48, 49, 257, DateTimeKind.Utc).AddTicks(3699), new DateTime(2020, 7, 11, 9, 48, 49, 257, DateTimeKind.Utc).AddTicks(3699) });

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "User",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2020, 7, 11, 9, 48, 49, 245, DateTimeKind.Utc).AddTicks(7609), new DateTime(2020, 7, 11, 9, 48, 49, 245, DateTimeKind.Utc).AddTicks(8266) });

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "User",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2020, 7, 11, 9, 48, 49, 246, DateTimeKind.Utc).AddTicks(1437), new DateTime(2020, 7, 11, 9, 48, 49, 246, DateTimeKind.Utc).AddTicks(1447) });

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "UserRole",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { 1L, 1L },
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2020, 7, 11, 9, 48, 49, 275, DateTimeKind.Utc).AddTicks(2902), new DateTime(2020, 7, 11, 9, 48, 49, 275, DateTimeKind.Utc).AddTicks(3800) });

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "UserRole",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { 2L, 2L },
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2020, 7, 11, 9, 48, 49, 275, DateTimeKind.Utc).AddTicks(7279), new DateTime(2020, 7, 11, 9, 48, 49, 275, DateTimeKind.Utc).AddTicks(7290) });
        }
    }
}
