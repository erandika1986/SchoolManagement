using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolManagement.Data.Migrations
{
    public partial class SMMS000005 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SubjectStream",
                schema: "Master",
                table: "Subject",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "Role",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2020, 8, 9, 3, 36, 53, 482, DateTimeKind.Utc).AddTicks(193), new DateTime(2020, 8, 9, 3, 36, 53, 482, DateTimeKind.Utc).AddTicks(2053) });

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "Role",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2020, 8, 9, 3, 36, 53, 482, DateTimeKind.Utc).AddTicks(6237), new DateTime(2020, 8, 9, 3, 36, 53, 482, DateTimeKind.Utc).AddTicks(6261) });

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "Role",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2020, 8, 9, 3, 36, 53, 482, DateTimeKind.Utc).AddTicks(6405), new DateTime(2020, 8, 9, 3, 36, 53, 482, DateTimeKind.Utc).AddTicks(6406) });

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "Role",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2020, 8, 9, 3, 36, 53, 482, DateTimeKind.Utc).AddTicks(6407), new DateTime(2020, 8, 9, 3, 36, 53, 482, DateTimeKind.Utc).AddTicks(6412) });

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "Role",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2020, 8, 9, 3, 36, 53, 482, DateTimeKind.Utc).AddTicks(6413), new DateTime(2020, 8, 9, 3, 36, 53, 482, DateTimeKind.Utc).AddTicks(6413) });

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "Role",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2020, 8, 9, 3, 36, 53, 482, DateTimeKind.Utc).AddTicks(6415), new DateTime(2020, 8, 9, 3, 36, 53, 482, DateTimeKind.Utc).AddTicks(6416) });

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "Role",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2020, 8, 9, 3, 36, 53, 482, DateTimeKind.Utc).AddTicks(6418), new DateTime(2020, 8, 9, 3, 36, 53, 482, DateTimeKind.Utc).AddTicks(6419) });

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "Role",
                keyColumn: "Id",
                keyValue: 8L,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2020, 8, 9, 3, 36, 53, 482, DateTimeKind.Utc).AddTicks(6420), new DateTime(2020, 8, 9, 3, 36, 53, 482, DateTimeKind.Utc).AddTicks(6420) });

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "User",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2020, 8, 9, 3, 36, 53, 450, DateTimeKind.Utc).AddTicks(743), new DateTime(2020, 8, 9, 3, 36, 53, 450, DateTimeKind.Utc).AddTicks(1703) });

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "User",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2020, 8, 9, 3, 36, 53, 450, DateTimeKind.Utc).AddTicks(4495), new DateTime(2020, 8, 9, 3, 36, 53, 450, DateTimeKind.Utc).AddTicks(4506) });

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "UserRole",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { 1L, 1L },
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2020, 8, 9, 3, 36, 53, 523, DateTimeKind.Utc).AddTicks(2992), new DateTime(2020, 8, 9, 3, 36, 53, 523, DateTimeKind.Utc).AddTicks(4192) });

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "UserRole",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { 2L, 2L },
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2020, 8, 9, 3, 36, 53, 524, DateTimeKind.Utc).AddTicks(125), new DateTime(2020, 8, 9, 3, 36, 53, 524, DateTimeKind.Utc).AddTicks(146) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SubjectStream",
                schema: "Master",
                table: "Subject");

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
    }
}
