using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolManagement.Data.Migrations
{
    public partial class SMMS000004 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClassCategory",
                schema: "Master",
                table: "Class",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "LanguageStream",
                schema: "Master",
                table: "Class",
                nullable: false,
                defaultValue: 2);

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "Role",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2020, 8, 9, 0, 43, 23, 509, DateTimeKind.Utc).AddTicks(3384), new DateTime(2020, 8, 9, 0, 43, 23, 509, DateTimeKind.Utc).AddTicks(5459) });

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "Role",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2020, 8, 9, 0, 43, 23, 509, DateTimeKind.Utc).AddTicks(9409), new DateTime(2020, 8, 9, 0, 43, 23, 509, DateTimeKind.Utc).AddTicks(9436) });

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "Role",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2020, 8, 9, 0, 43, 23, 509, DateTimeKind.Utc).AddTicks(9517), new DateTime(2020, 8, 9, 0, 43, 23, 509, DateTimeKind.Utc).AddTicks(9518) });

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "Role",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2020, 8, 9, 0, 43, 23, 509, DateTimeKind.Utc).AddTicks(9520), new DateTime(2020, 8, 9, 0, 43, 23, 509, DateTimeKind.Utc).AddTicks(9520) });

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "Role",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2020, 8, 9, 0, 43, 23, 509, DateTimeKind.Utc).AddTicks(9522), new DateTime(2020, 8, 9, 0, 43, 23, 509, DateTimeKind.Utc).AddTicks(9522) });

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "Role",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2020, 8, 9, 0, 43, 23, 509, DateTimeKind.Utc).AddTicks(9523), new DateTime(2020, 8, 9, 0, 43, 23, 509, DateTimeKind.Utc).AddTicks(9523) });

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "Role",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2020, 8, 9, 0, 43, 23, 509, DateTimeKind.Utc).AddTicks(9524), new DateTime(2020, 8, 9, 0, 43, 23, 509, DateTimeKind.Utc).AddTicks(9524) });

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "Role",
                keyColumn: "Id",
                keyValue: 8L,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2020, 8, 9, 0, 43, 23, 509, DateTimeKind.Utc).AddTicks(9525), new DateTime(2020, 8, 9, 0, 43, 23, 509, DateTimeKind.Utc).AddTicks(9526) });

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "User",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2020, 8, 9, 0, 43, 23, 495, DateTimeKind.Utc).AddTicks(3039), new DateTime(2020, 8, 9, 0, 43, 23, 495, DateTimeKind.Utc).AddTicks(3673) });

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "User",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2020, 8, 9, 0, 43, 23, 495, DateTimeKind.Utc).AddTicks(6467), new DateTime(2020, 8, 9, 0, 43, 23, 495, DateTimeKind.Utc).AddTicks(6483) });

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "UserRole",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { 1L, 1L },
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2020, 8, 9, 0, 43, 23, 529, DateTimeKind.Utc).AddTicks(1316), new DateTime(2020, 8, 9, 0, 43, 23, 529, DateTimeKind.Utc).AddTicks(2401) });

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "UserRole",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { 2L, 2L },
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2020, 8, 9, 0, 43, 23, 529, DateTimeKind.Utc).AddTicks(7359), new DateTime(2020, 8, 9, 0, 43, 23, 529, DateTimeKind.Utc).AddTicks(7373) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClassCategory",
                schema: "Master",
                table: "Class");

            migrationBuilder.DropColumn(
                name: "LanguageStream",
                schema: "Master",
                table: "Class");

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
        }
    }
}
