using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolManagement.Master.Data.Migrations
{
    public partial class SMMasterMS000001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Schools",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SchoolName = table.Column<string>(nullable: true),
                    SchoolDomain = table.Column<string>(nullable: true),
                    SchoolLog = table.Column<string>(nullable: true),
                    ConnectionString = table.Column<string>(nullable: true),
                    SMTPServer = table.Column<string>(nullable: true),
                    SMTPUsername = table.Column<string>(nullable: true),
                    SMTPPassword = table.Column<string>(nullable: true),
                    SMTPFrom = table.Column<string>(nullable: true),
                    SMTPPort = table.Column<int>(nullable: false),
                    IsSMTPUseSSL = table.Column<bool>(nullable: false),
                    TenantId = table.Column<Guid>(nullable: false, defaultValue: new Guid("82b83b13-93e9-410c-ad92-d1c6ef598126")),
                    APIKey = table.Column<Guid>(nullable: false, defaultValue: new Guid("2c701132-ac1b-4b46-91c1-ef7ed08ed6e6")),
                    SecretKey = table.Column<Guid>(nullable: false, defaultValue: new Guid("82cf1f34-3ba6-46bc-a4df-c8ebb1e339c3")),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schools", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Schools");
        }
    }
}
