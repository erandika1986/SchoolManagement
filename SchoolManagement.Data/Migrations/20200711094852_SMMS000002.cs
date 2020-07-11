using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolManagement.Data.Migrations
{
    public partial class SMMS000002 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Username",
                schema: "Account",
                table: "User",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                schema: "Account",
                table: "User",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_User_Email",
                schema: "Account",
                table: "User",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_User_Username",
                schema: "Account",
                table: "User",
                column: "Username",
                unique: true,
                filter: "[Username] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_User_Email",
                schema: "Account",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_Username",
                schema: "Account",
                table: "User");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                schema: "Account",
                table: "User",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                schema: "Account",
                table: "User",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "Role",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2020, 6, 21, 22, 28, 28, 503, DateTimeKind.Utc).AddTicks(9857), new DateTime(2020, 6, 21, 22, 28, 28, 504, DateTimeKind.Utc).AddTicks(1155) });

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "Role",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2020, 6, 21, 22, 28, 28, 504, DateTimeKind.Utc).AddTicks(3954), new DateTime(2020, 6, 21, 22, 28, 28, 504, DateTimeKind.Utc).AddTicks(3969) });

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "Role",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2020, 6, 21, 22, 28, 28, 504, DateTimeKind.Utc).AddTicks(4044), new DateTime(2020, 6, 21, 22, 28, 28, 504, DateTimeKind.Utc).AddTicks(4045) });

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "Role",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2020, 6, 21, 22, 28, 28, 504, DateTimeKind.Utc).AddTicks(4046), new DateTime(2020, 6, 21, 22, 28, 28, 504, DateTimeKind.Utc).AddTicks(4046) });

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "Role",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2020, 6, 21, 22, 28, 28, 504, DateTimeKind.Utc).AddTicks(4047), new DateTime(2020, 6, 21, 22, 28, 28, 504, DateTimeKind.Utc).AddTicks(4048) });

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "Role",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2020, 6, 21, 22, 28, 28, 504, DateTimeKind.Utc).AddTicks(4049), new DateTime(2020, 6, 21, 22, 28, 28, 504, DateTimeKind.Utc).AddTicks(4049) });

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "Role",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2020, 6, 21, 22, 28, 28, 504, DateTimeKind.Utc).AddTicks(4050), new DateTime(2020, 6, 21, 22, 28, 28, 504, DateTimeKind.Utc).AddTicks(4050) });

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "Role",
                keyColumn: "Id",
                keyValue: 8L,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2020, 6, 21, 22, 28, 28, 504, DateTimeKind.Utc).AddTicks(4051), new DateTime(2020, 6, 21, 22, 28, 28, 504, DateTimeKind.Utc).AddTicks(4052) });

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "User",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2020, 6, 21, 22, 28, 28, 494, DateTimeKind.Utc).AddTicks(9758), new DateTime(2020, 6, 21, 22, 28, 28, 495, DateTimeKind.Utc).AddTicks(390) });

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "User",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2020, 6, 21, 22, 28, 28, 495, DateTimeKind.Utc).AddTicks(2273), new DateTime(2020, 6, 21, 22, 28, 28, 495, DateTimeKind.Utc).AddTicks(2282) });

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "UserRole",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { 1L, 1L },
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2020, 6, 21, 22, 28, 28, 519, DateTimeKind.Utc).AddTicks(3301), new DateTime(2020, 6, 21, 22, 28, 28, 519, DateTimeKind.Utc).AddTicks(4108) });

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "UserRole",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { 2L, 2L },
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2020, 6, 21, 22, 28, 28, 519, DateTimeKind.Utc).AddTicks(7890), new DateTime(2020, 6, 21, 22, 28, 28, 519, DateTimeKind.Utc).AddTicks(7901) });
        }
    }
}
