using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolManagement.Data.Migrations
{
    public partial class SMMS000001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Master");

            migrationBuilder.EnsureSchema(
                name: "Lesson");

            migrationBuilder.EnsureSchema(
                name: "Analysis");

            migrationBuilder.EnsureSchema(
                name: "Account");

            migrationBuilder.CreateTable(
                name: "User",
                schema: "Account",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(nullable: true),
                    NickName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true),
                    MobileNo = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    LastLoggedInTime = table.Column<DateTime>(nullable: true),
                    LoginSessionId = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatedById = table.Column<long>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedById = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_User_CreatedById",
                        column: x => x.CreatedById,
                        principalSchema: "Account",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_User_User_UpdatedById",
                        column: x => x.UpdatedById,
                        principalSchema: "Account",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Grade",
                schema: "Analysis",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Standard = table.Column<string>(nullable: true),
                    MaxMarks = table.Column<float>(nullable: false),
                    MinMarks = table.Column<float>(nullable: false),
                    ColorCode = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grade", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                schema: "Account",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatedById = table.Column<long>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedById = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Role_User_CreatedById",
                        column: x => x.CreatedById,
                        principalSchema: "Account",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Role_User_UpdatedById",
                        column: x => x.UpdatedById,
                        principalSchema: "Account",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AcademicLevel",
                schema: "Master",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: false),
                    LevelHeadId = table.Column<long>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatedById = table.Column<long>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedById = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcademicLevel", x => x.Id);
                    table.UniqueConstraint("AK_AcademicLevel_Description", x => x.Description);
                    table.ForeignKey(
                        name: "FK_AcademicLevel_User_CreatedById",
                        column: x => x.CreatedById,
                        principalSchema: "Account",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AcademicLevel_User_LevelHeadId",
                        column: x => x.LevelHeadId,
                        principalSchema: "Account",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AcademicLevel_User_UpdatedById",
                        column: x => x.UpdatedById,
                        principalSchema: "Account",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AcademicYear",
                schema: "Master",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatedById = table.Column<long>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedById = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcademicYear", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AcademicYear_User_CreatedById",
                        column: x => x.CreatedById,
                        principalSchema: "Account",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AcademicYear_User_UpdatedById",
                        column: x => x.UpdatedById,
                        principalSchema: "Account",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AssessmentType",
                schema: "Master",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatedById = table.Column<long>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedById = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssessmentType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssessmentType_User_CreatedById",
                        column: x => x.CreatedById,
                        principalSchema: "Account",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AssessmentType_User_UpdatedById",
                        column: x => x.UpdatedById,
                        principalSchema: "Account",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClassName",
                schema: "Master",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    CockpitName = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatedById = table.Column<long>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedById = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassName", x => x.Id);
                    table.UniqueConstraint("AK_ClassName_Name", x => x.Name);
                    table.ForeignKey(
                        name: "FK_ClassName_User_CreatedById",
                        column: x => x.CreatedById,
                        principalSchema: "Account",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClassName_User_UpdatedById",
                        column: x => x.UpdatedById,
                        principalSchema: "Account",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Day",
                schema: "Master",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatedById = table.Column<long>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedById = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Day", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Day_User_CreatedById",
                        column: x => x.CreatedById,
                        principalSchema: "Account",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Day_User_UpdatedById",
                        column: x => x.UpdatedById,
                        principalSchema: "Account",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Period",
                schema: "Master",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    StartTime = table.Column<DateTime>(nullable: false),
                    EndTime = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatedById = table.Column<long>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedById = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Period", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Period_User_CreatedById",
                        column: x => x.CreatedById,
                        principalSchema: "Account",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Period_User_UpdatedById",
                        column: x => x.UpdatedById,
                        principalSchema: "Account",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                schema: "Master",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdmissionNo = table.Column<string>(nullable: true),
                    FullName = table.Column<string>(nullable: true),
                    EmegencyContactNo1 = table.Column<string>(nullable: true),
                    EmegencyContactNo2 = table.Column<string>(nullable: true),
                    Gender = table.Column<int>(nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatedById = table.Column<long>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedById = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Student_User_CreatedById",
                        column: x => x.CreatedById,
                        principalSchema: "Account",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Student_User_UpdatedById",
                        column: x => x.UpdatedById,
                        principalSchema: "Account",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Subject",
                schema: "Master",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    SubjectCode = table.Column<string>(nullable: false),
                    SubjectCategory = table.Column<int>(nullable: false),
                    IsParentBasketSubject = table.Column<bool>(nullable: false),
                    IsBuscketSubject = table.Column<bool>(nullable: false),
                    ParentBasketSubjectId = table.Column<long>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatedById = table.Column<long>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedById = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subject", x => x.Id);
                    table.UniqueConstraint("AK_Subject_Name", x => x.Name);
                    table.UniqueConstraint("AK_Subject_SubjectCode", x => x.SubjectCode);
                    table.ForeignKey(
                        name: "FK_Subject_User_CreatedById",
                        column: x => x.CreatedById,
                        principalSchema: "Account",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Subject_Subject_ParentBasketSubjectId",
                        column: x => x.ParentBasketSubjectId,
                        principalSchema: "Master",
                        principalTable: "Subject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Subject_User_UpdatedById",
                        column: x => x.UpdatedById,
                        principalSchema: "Account",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                schema: "Account",
                columns: table => new
                {
                    UserId = table.Column<long>(nullable: false),
                    RoleId = table.Column<long>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatedById = table.Column<long>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedById = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRole_User_CreatedById",
                        column: x => x.CreatedById,
                        principalSchema: "Account",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserRole_Role_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "Account",
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserRole_User_UpdatedById",
                        column: x => x.UpdatedById,
                        principalSchema: "Account",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserRole_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "Account",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AssessmentTypeAcademicLevel",
                schema: "Master",
                columns: table => new
                {
                    AssessmentTypeId = table.Column<long>(nullable: false),
                    AcademicLevelId = table.Column<long>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatedById = table.Column<long>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedById = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssessmentTypeAcademicLevel", x => new { x.AssessmentTypeId, x.AcademicLevelId });
                    table.ForeignKey(
                        name: "FK_AssessmentTypeAcademicLevel_AcademicLevel_AcademicLevelId",
                        column: x => x.AcademicLevelId,
                        principalSchema: "Master",
                        principalTable: "AcademicLevel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AssessmentTypeAcademicLevel_AssessmentType_AssessmentTypeId",
                        column: x => x.AssessmentTypeId,
                        principalSchema: "Master",
                        principalTable: "AssessmentType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AssessmentTypeAcademicLevel_User_CreatedById",
                        column: x => x.CreatedById,
                        principalSchema: "Account",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AssessmentTypeAcademicLevel_User_UpdatedById",
                        column: x => x.UpdatedById,
                        principalSchema: "Account",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Class",
                schema: "Master",
                columns: table => new
                {
                    ClassNameId = table.Column<long>(nullable: false),
                    AcademicLevelId = table.Column<long>(nullable: false),
                    AcademicYearId = table.Column<long>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatedById = table.Column<long>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedById = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Class", x => new { x.ClassNameId, x.AcademicLevelId, x.AcademicYearId });
                    table.ForeignKey(
                        name: "FK_Class_AcademicLevel_AcademicLevelId",
                        column: x => x.AcademicLevelId,
                        principalSchema: "Master",
                        principalTable: "AcademicLevel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Class_AcademicYear_AcademicYearId",
                        column: x => x.AcademicYearId,
                        principalSchema: "Master",
                        principalTable: "AcademicYear",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Class_ClassName_ClassNameId",
                        column: x => x.ClassNameId,
                        principalSchema: "Master",
                        principalTable: "ClassName",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Class_User_CreatedById",
                        column: x => x.CreatedById,
                        principalSchema: "Account",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Class_User_UpdatedById",
                        column: x => x.UpdatedById,
                        principalSchema: "Account",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LockingDate",
                schema: "Master",
                columns: table => new
                {
                    AcademicYearId = table.Column<long>(nullable: false),
                    AcademicLevelId = table.Column<long>(nullable: false),
                    SubjectId = table.Column<long>(nullable: false),
                    AssessmentTypeId = table.Column<long>(nullable: false),
                    TOSLockingDate = table.Column<DateTime>(nullable: true),
                    ResultLockingDate = table.Column<DateTime>(nullable: true),
                    HasExam = table.Column<bool>(nullable: false),
                    IsResultMigrated = table.Column<bool>(nullable: false),
                    MigratedDate = table.Column<DateTime>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatedById = table.Column<long>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedById = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LockingDate", x => new { x.AcademicYearId, x.AcademicLevelId, x.SubjectId, x.AssessmentTypeId });
                    table.ForeignKey(
                        name: "FK_LockingDate_AcademicLevel_AcademicLevelId",
                        column: x => x.AcademicLevelId,
                        principalSchema: "Master",
                        principalTable: "AcademicLevel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LockingDate_AcademicYear_AcademicYearId",
                        column: x => x.AcademicYearId,
                        principalSchema: "Master",
                        principalTable: "AcademicYear",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LockingDate_AssessmentType_AssessmentTypeId",
                        column: x => x.AssessmentTypeId,
                        principalSchema: "Master",
                        principalTable: "AssessmentType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LockingDate_User_CreatedById",
                        column: x => x.CreatedById,
                        principalSchema: "Account",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LockingDate_Subject_SubjectId",
                        column: x => x.SubjectId,
                        principalSchema: "Master",
                        principalTable: "Subject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LockingDate_User_UpdatedById",
                        column: x => x.UpdatedById,
                        principalSchema: "Account",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SubjectAcademicLevel",
                schema: "Master",
                columns: table => new
                {
                    SubjectId = table.Column<long>(nullable: false),
                    AcademicLevelId = table.Column<long>(nullable: false),
                    NoOfPeriodPerWeek = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatedById = table.Column<long>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedById = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectAcademicLevel", x => new { x.SubjectId, x.AcademicLevelId });
                    table.ForeignKey(
                        name: "FK_SubjectAcademicLevel_AcademicLevel_AcademicLevelId",
                        column: x => x.AcademicLevelId,
                        principalSchema: "Master",
                        principalTable: "AcademicLevel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SubjectAcademicLevel_User_CreatedById",
                        column: x => x.CreatedById,
                        principalSchema: "Account",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SubjectAcademicLevel_Subject_SubjectId",
                        column: x => x.SubjectId,
                        principalSchema: "Master",
                        principalTable: "Subject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SubjectAcademicLevel_User_UpdatedById",
                        column: x => x.UpdatedById,
                        principalSchema: "Account",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClassTeacher",
                schema: "Master",
                columns: table => new
                {
                    ClassNameId = table.Column<long>(nullable: false),
                    AcademicLevelId = table.Column<long>(nullable: false),
                    AcademicYearId = table.Column<long>(nullable: false),
                    TeacherId = table.Column<long>(nullable: false),
                    IsPrimary = table.Column<bool>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatedById = table.Column<long>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedById = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassTeacher", x => new { x.ClassNameId, x.AcademicLevelId, x.AcademicYearId, x.TeacherId });
                    table.ForeignKey(
                        name: "FK_ClassTeacher_User_CreatedById",
                        column: x => x.CreatedById,
                        principalSchema: "Account",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClassTeacher_User_TeacherId",
                        column: x => x.TeacherId,
                        principalSchema: "Account",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClassTeacher_User_UpdatedById",
                        column: x => x.UpdatedById,
                        principalSchema: "Account",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClassTeacher_Class_ClassNameId_AcademicLevelId_AcademicYearId",
                        columns: x => new { x.ClassNameId, x.AcademicLevelId, x.AcademicYearId },
                        principalSchema: "Master",
                        principalTable: "Class",
                        principalColumns: new[] { "ClassNameId", "AcademicLevelId", "AcademicYearId" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentClass",
                schema: "Master",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<long>(nullable: false),
                    ClassNameId = table.Column<long>(nullable: false),
                    AcademicLevelId = table.Column<long>(nullable: false),
                    AcademicYearId = table.Column<long>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatedById = table.Column<long>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedById = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentClass", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentClass_User_CreatedById",
                        column: x => x.CreatedById,
                        principalSchema: "Account",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentClass_Student_StudentId",
                        column: x => x.StudentId,
                        principalSchema: "Master",
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentClass_User_UpdatedById",
                        column: x => x.UpdatedById,
                        principalSchema: "Account",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentClass_Class_ClassNameId_AcademicLevelId_AcademicYearId",
                        columns: x => new { x.ClassNameId, x.AcademicLevelId, x.AcademicYearId },
                        principalSchema: "Master",
                        principalTable: "Class",
                        principalColumns: new[] { "ClassNameId", "AcademicLevelId", "AcademicYearId" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Lesson",
                schema: "Lesson",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    OwnerId = table.Column<long>(nullable: false),
                    AcademicLevelId = table.Column<long>(nullable: false),
                    ClassNameId = table.Column<long>(nullable: true),
                    AcademicYearId = table.Column<long>(nullable: true),
                    SubjectId = table.Column<long>(nullable: false),
                    LearningOutcome = table.Column<string>(nullable: true),
                    PlannedDate = table.Column<DateTime>(nullable: true),
                    CompletedDate = table.Column<DateTime>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    VersionNo = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatedById = table.Column<long>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedById = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lesson", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lesson_User_CreatedById",
                        column: x => x.CreatedById,
                        principalSchema: "Account",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Lesson_User_OwnerId",
                        column: x => x.OwnerId,
                        principalSchema: "Account",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Lesson_User_UpdatedById",
                        column: x => x.UpdatedById,
                        principalSchema: "Account",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Lesson_SubjectAcademicLevel_SubjectId_AcademicLevelId",
                        columns: x => new { x.SubjectId, x.AcademicLevelId },
                        principalSchema: "Master",
                        principalTable: "SubjectAcademicLevel",
                        principalColumns: new[] { "SubjectId", "AcademicLevelId" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Lesson_Class_ClassNameId_AcademicLevelId_AcademicYearId",
                        columns: x => new { x.ClassNameId, x.AcademicLevelId, x.AcademicYearId },
                        principalSchema: "Master",
                        principalTable: "Class",
                        principalColumns: new[] { "ClassNameId", "AcademicLevelId", "AcademicYearId" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClassTimeTablePeriod",
                schema: "Master",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassNameId = table.Column<long>(nullable: false),
                    AcademicLevelId = table.Column<long>(nullable: false),
                    AcademicYearId = table.Column<long>(nullable: false),
                    DayId = table.Column<long>(nullable: false),
                    PeriodId = table.Column<long>(nullable: false),
                    SubjectId = table.Column<long>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatedById = table.Column<long>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedById = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassTimeTablePeriod", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClassTimeTablePeriod_User_CreatedById",
                        column: x => x.CreatedById,
                        principalSchema: "Account",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClassTimeTablePeriod_Day_DayId",
                        column: x => x.DayId,
                        principalSchema: "Master",
                        principalTable: "Day",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClassTimeTablePeriod_Period_PeriodId",
                        column: x => x.PeriodId,
                        principalSchema: "Master",
                        principalTable: "Period",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClassTimeTablePeriod_User_UpdatedById",
                        column: x => x.UpdatedById,
                        principalSchema: "Account",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClassTimeTablePeriod_SubjectAcademicLevel_SubjectId_AcademicLevelId",
                        columns: x => new { x.SubjectId, x.AcademicLevelId },
                        principalSchema: "Master",
                        principalTable: "SubjectAcademicLevel",
                        principalColumns: new[] { "SubjectId", "AcademicLevelId" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClassTimeTablePeriod_Class_ClassNameId_AcademicLevelId_AcademicYearId",
                        columns: x => new { x.ClassNameId, x.AcademicLevelId, x.AcademicYearId },
                        principalSchema: "Master",
                        principalTable: "Class",
                        principalColumns: new[] { "ClassNameId", "AcademicLevelId", "AcademicYearId" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HeadOfDepartment",
                schema: "Master",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AcademicYearId = table.Column<long>(nullable: false),
                    AcademicLevelId = table.Column<long>(nullable: false),
                    SubjectId = table.Column<long>(nullable: false),
                    TeacherId = table.Column<long>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatedById = table.Column<long>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedById = table.Column<long>(nullable: false),
                    SubjectAcademicLevelAcademicLevelId = table.Column<long>(nullable: true),
                    SubjectAcademicLevelSubjectId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeadOfDepartment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HeadOfDepartment_AcademicLevel_AcademicLevelId",
                        column: x => x.AcademicLevelId,
                        principalSchema: "Master",
                        principalTable: "AcademicLevel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HeadOfDepartment_AcademicYear_AcademicYearId",
                        column: x => x.AcademicYearId,
                        principalSchema: "Master",
                        principalTable: "AcademicYear",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HeadOfDepartment_User_CreatedById",
                        column: x => x.CreatedById,
                        principalSchema: "Account",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HeadOfDepartment_Subject_SubjectId",
                        column: x => x.SubjectId,
                        principalSchema: "Master",
                        principalTable: "Subject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HeadOfDepartment_User_TeacherId",
                        column: x => x.TeacherId,
                        principalSchema: "Account",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HeadOfDepartment_User_UpdatedById",
                        column: x => x.UpdatedById,
                        principalSchema: "Account",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HeadOfDepartment_SubjectAcademicLevel_SubjectAcademicLevelSubjectId_SubjectAcademicLevelAcademicLevelId",
                        columns: x => new { x.SubjectAcademicLevelSubjectId, x.SubjectAcademicLevelAcademicLevelId },
                        principalSchema: "Master",
                        principalTable: "SubjectAcademicLevel",
                        principalColumns: new[] { "SubjectId", "AcademicLevelId" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentSubject",
                schema: "Master",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AcademicYearId = table.Column<long>(nullable: false),
                    StudentId = table.Column<long>(nullable: false),
                    AcademicLevelId = table.Column<long>(nullable: false),
                    SubjectId = table.Column<long>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatedById = table.Column<long>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedById = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentSubject", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentSubject_AcademicLevel_AcademicLevelId",
                        column: x => x.AcademicLevelId,
                        principalSchema: "Master",
                        principalTable: "AcademicLevel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentSubject_AcademicYear_AcademicYearId",
                        column: x => x.AcademicYearId,
                        principalSchema: "Master",
                        principalTable: "AcademicYear",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentSubject_User_CreatedById",
                        column: x => x.CreatedById,
                        principalSchema: "Account",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentSubject_Student_StudentId",
                        column: x => x.StudentId,
                        principalSchema: "Master",
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentSubject_Subject_SubjectId",
                        column: x => x.SubjectId,
                        principalSchema: "Master",
                        principalTable: "Subject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentSubject_User_UpdatedById",
                        column: x => x.UpdatedById,
                        principalSchema: "Account",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentSubject_SubjectAcademicLevel_SubjectId_AcademicLevelId",
                        columns: x => new { x.SubjectId, x.AcademicLevelId },
                        principalSchema: "Master",
                        principalTable: "SubjectAcademicLevel",
                        principalColumns: new[] { "SubjectId", "AcademicLevelId" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SubjectTeacher",
                schema: "Master",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AcademicLevelId = table.Column<long>(nullable: false),
                    AcademicYearId = table.Column<long>(nullable: false),
                    SubjectId = table.Column<long>(nullable: false),
                    TeacherId = table.Column<long>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatedById = table.Column<long>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedById = table.Column<long>(nullable: false),
                    ClassAcademicLevelId = table.Column<long>(nullable: true),
                    ClassAcademicYearId = table.Column<long>(nullable: true),
                    ClassNameId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectTeacher", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubjectTeacher_AcademicYear_AcademicYearId",
                        column: x => x.AcademicYearId,
                        principalSchema: "Master",
                        principalTable: "AcademicYear",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SubjectTeacher_User_CreatedById",
                        column: x => x.CreatedById,
                        principalSchema: "Account",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SubjectTeacher_User_TeacherId",
                        column: x => x.TeacherId,
                        principalSchema: "Account",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SubjectTeacher_User_UpdatedById",
                        column: x => x.UpdatedById,
                        principalSchema: "Account",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SubjectTeacher_SubjectAcademicLevel_SubjectId_AcademicLevelId",
                        columns: x => new { x.SubjectId, x.AcademicLevelId },
                        principalSchema: "Master",
                        principalTable: "SubjectAcademicLevel",
                        principalColumns: new[] { "SubjectId", "AcademicLevelId" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SubjectTeacher_Class_ClassNameId_ClassAcademicLevelId_ClassAcademicYearId",
                        columns: x => new { x.ClassNameId, x.ClassAcademicLevelId, x.ClassAcademicYearId },
                        principalSchema: "Master",
                        principalTable: "Class",
                        principalColumns: new[] { "ClassNameId", "AcademicLevelId", "AcademicYearId" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentLesson",
                schema: "Lesson",
                columns: table => new
                {
                    StudentId = table.Column<long>(nullable: false),
                    LessonId = table.Column<long>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    JoinDate = table.Column<DateTime>(nullable: true),
                    CompletedDate = table.Column<DateTime>(nullable: true),
                    LessonMark = table.Column<decimal>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentLesson", x => new { x.StudentId, x.LessonId });
                    table.ForeignKey(
                        name: "FK_StudentLesson_Lesson_LessonId",
                        column: x => x.LessonId,
                        principalSchema: "Lesson",
                        principalTable: "Lesson",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentLesson_User_StudentId",
                        column: x => x.StudentId,
                        principalSchema: "Account",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Topic",
                schema: "Lesson",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LessonId = table.Column<long>(nullable: false),
                    SequenceNo = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    LearningExperience = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topic", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Topic_Lesson_LessonId",
                        column: x => x.LessonId,
                        principalSchema: "Lesson",
                        principalTable: "Lesson",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClassTimeTablePeriodAssignTeacher",
                schema: "Master",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassTimeTablePeriodId = table.Column<long>(nullable: false),
                    TeacherId = table.Column<long>(nullable: false),
                    AllocatedDate = table.Column<DateTime>(nullable: false),
                    DeallocatedDate = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatedById = table.Column<long>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedById = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassTimeTablePeriodAssignTeacher", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClassTimeTablePeriodAssignTeacher_ClassTimeTablePeriod_ClassTimeTablePeriodId",
                        column: x => x.ClassTimeTablePeriodId,
                        principalSchema: "Master",
                        principalTable: "ClassTimeTablePeriod",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClassTimeTablePeriodAssignTeacher_User_CreatedById",
                        column: x => x.CreatedById,
                        principalSchema: "Account",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClassTimeTablePeriodAssignTeacher_User_TeacherId",
                        column: x => x.TeacherId,
                        principalSchema: "Account",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClassTimeTablePeriodAssignTeacher_User_UpdatedById",
                        column: x => x.UpdatedById,
                        principalSchema: "Account",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentSubjectScore",
                schema: "Analysis",
                columns: table => new
                {
                    AssessmentTypeId = table.Column<long>(nullable: false),
                    StudentSubjectId = table.Column<long>(nullable: false),
                    GainedScore = table.Column<float>(nullable: false),
                    ScorePercent = table.Column<float>(nullable: false),
                    AllocatedScore = table.Column<float>(nullable: false),
                    GradeId = table.Column<long>(nullable: false),
                    LevelRank = table.Column<int>(nullable: false),
                    ScoreDifference = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentSubjectScore", x => new { x.AssessmentTypeId, x.StudentSubjectId });
                    table.ForeignKey(
                        name: "FK_StudentSubjectScore_AssessmentType_AssessmentTypeId",
                        column: x => x.AssessmentTypeId,
                        principalSchema: "Master",
                        principalTable: "AssessmentType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentSubjectScore_Grade_GradeId",
                        column: x => x.GradeId,
                        principalSchema: "Analysis",
                        principalTable: "Grade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentSubjectScore_StudentSubject_StudentSubjectId",
                        column: x => x.StudentSubjectId,
                        principalSchema: "Master",
                        principalTable: "StudentSubject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClassSubjectTeacher",
                schema: "Master",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassNameId = table.Column<long>(nullable: false),
                    AcademicLevelId = table.Column<long>(nullable: false),
                    AcademicYearId = table.Column<long>(nullable: false),
                    SubjectId = table.Column<long>(nullable: false),
                    SubjectTeacherId = table.Column<long>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatedById = table.Column<long>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedById = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassSubjectTeacher", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClassSubjectTeacher_User_CreatedById",
                        column: x => x.CreatedById,
                        principalSchema: "Account",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClassSubjectTeacher_SubjectTeacher_SubjectTeacherId",
                        column: x => x.SubjectTeacherId,
                        principalSchema: "Master",
                        principalTable: "SubjectTeacher",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClassSubjectTeacher_User_UpdatedById",
                        column: x => x.UpdatedById,
                        principalSchema: "Account",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClassSubjectTeacher_SubjectAcademicLevel_SubjectId_AcademicLevelId",
                        columns: x => new { x.SubjectId, x.AcademicLevelId },
                        principalSchema: "Master",
                        principalTable: "SubjectAcademicLevel",
                        principalColumns: new[] { "SubjectId", "AcademicLevelId" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClassSubjectTeacher_Class_ClassNameId_AcademicLevelId_AcademicYearId",
                        columns: x => new { x.ClassNameId, x.AcademicLevelId, x.AcademicYearId },
                        principalSchema: "Master",
                        principalTable: "Class",
                        principalColumns: new[] { "ClassNameId", "AcademicLevelId", "AcademicYearId" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LessonChat",
                schema: "Lesson",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LessonId = table.Column<long>(nullable: false),
                    TopicId = table.Column<long>(nullable: true),
                    FromUserId = table.Column<long>(nullable: false),
                    ToUserId = table.Column<long>(nullable: false),
                    Message = table.Column<string>(nullable: true),
                    MessageType = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LessonChat", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LessonChat_User_FromUserId",
                        column: x => x.FromUserId,
                        principalSchema: "Account",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LessonChat_Lesson_LessonId",
                        column: x => x.LessonId,
                        principalSchema: "Lesson",
                        principalTable: "Lesson",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LessonChat_User_ToUserId",
                        column: x => x.ToUserId,
                        principalSchema: "Account",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LessonChat_Topic_TopicId",
                        column: x => x.TopicId,
                        principalSchema: "Lesson",
                        principalTable: "Topic",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Question",
                schema: "Lesson",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LessonId = table.Column<long>(nullable: true),
                    TopicId = table.Column<long>(nullable: true),
                    SequenceNo = table.Column<int>(nullable: false),
                    QuestionText = table.Column<string>(nullable: true),
                    Marks = table.Column<decimal>(nullable: false),
                    QuestionLevel = table.Column<int>(nullable: false),
                    QuestionType = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Question", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Question_Lesson_LessonId",
                        column: x => x.LessonId,
                        principalSchema: "Lesson",
                        principalTable: "Lesson",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Question_Topic_TopicId",
                        column: x => x.TopicId,
                        principalSchema: "Lesson",
                        principalTable: "Topic",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentTopic",
                schema: "Lesson",
                columns: table => new
                {
                    StudentId = table.Column<long>(nullable: false),
                    TopicId = table.Column<long>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    JoinDate = table.Column<DateTime>(nullable: true),
                    CompletedDate = table.Column<DateTime>(nullable: true),
                    TaskMarks = table.Column<decimal>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentTopic", x => new { x.StudentId, x.TopicId });
                    table.ForeignKey(
                        name: "FK_StudentTopic_User_StudentId",
                        column: x => x.StudentId,
                        principalSchema: "Account",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentTopic_Topic_TopicId",
                        column: x => x.TopicId,
                        principalSchema: "Lesson",
                        principalTable: "Topic",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TopicContent",
                schema: "Lesson",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TopicId = table.Column<long>(nullable: false),
                    Introduction = table.Column<string>(nullable: true),
                    ContentType = table.Column<int>(nullable: false),
                    Content = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TopicContent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TopicContent_Topic_TopicId",
                        column: x => x.TopicId,
                        principalSchema: "Lesson",
                        principalTable: "Topic",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EssayAnswer",
                schema: "Lesson",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestonId = table.Column<long>(nullable: false),
                    AnswerText = table.Column<string>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EssayAnswer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EssayAnswer_Question_QuestonId",
                        column: x => x.QuestonId,
                        principalSchema: "Lesson",
                        principalTable: "Question",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EssayStudentAnswer",
                schema: "Lesson",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestonId = table.Column<long>(nullable: false),
                    StudentId = table.Column<long>(nullable: false),
                    AnswerText = table.Column<string>(nullable: true),
                    TeacherComments = table.Column<string>(nullable: true),
                    Marks = table.Column<decimal>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EssayStudentAnswer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EssayStudentAnswer_Question_QuestonId",
                        column: x => x.QuestonId,
                        principalSchema: "Lesson",
                        principalTable: "Question",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EssayStudentAnswer_User_StudentId",
                        column: x => x.StudentId,
                        principalSchema: "Account",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MCQAnswer",
                schema: "Lesson",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestonId = table.Column<long>(nullable: false),
                    AnswerText = table.Column<string>(nullable: true),
                    SequenceNo = table.Column<int>(nullable: false),
                    IsCorrectAnswer = table.Column<bool>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MCQAnswer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MCQAnswer_Question_QuestonId",
                        column: x => x.QuestonId,
                        principalSchema: "Lesson",
                        principalTable: "Question",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MCQStudentQuestion",
                schema: "Lesson",
                columns: table => new
                {
                    QuestionId = table.Column<long>(nullable: false),
                    StudentId = table.Column<long>(nullable: false),
                    Marks = table.Column<decimal>(nullable: true),
                    IsCorrect = table.Column<bool>(nullable: true),
                    TeacherComments = table.Column<string>(nullable: true),
                    SubmittedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MCQStudentQuestion", x => new { x.StudentId, x.QuestionId });
                    table.ForeignKey(
                        name: "FK_MCQStudentQuestion_Question_QuestionId",
                        column: x => x.QuestionId,
                        principalSchema: "Lesson",
                        principalTable: "Question",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MCQStudentQuestion_User_StudentId",
                        column: x => x.StudentId,
                        principalSchema: "Account",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MCQStudentAnswer",
                schema: "Lesson",
                columns: table => new
                {
                    MCQAnswerId = table.Column<long>(nullable: false),
                    StudentId = table.Column<long>(nullable: false),
                    QuestionId = table.Column<long>(nullable: false),
                    AnswerText = table.Column<string>(nullable: true),
                    SequenceNo = table.Column<int>(nullable: false),
                    IsCorrectAnswer = table.Column<bool>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MCQStudentAnswer", x => new { x.MCQAnswerId, x.StudentId, x.QuestionId });
                    table.ForeignKey(
                        name: "FK_MCQStudentAnswer_MCQAnswer_MCQAnswerId",
                        column: x => x.MCQAnswerId,
                        principalSchema: "Lesson",
                        principalTable: "MCQAnswer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MCQStudentAnswer_MCQStudentQuestion_StudentId_QuestionId",
                        columns: x => new { x.StudentId, x.QuestionId },
                        principalSchema: "Lesson",
                        principalTable: "MCQStudentQuestion",
                        principalColumns: new[] { "StudentId", "QuestionId" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                schema: "Account",
                table: "User",
                columns: new[] { "Id", "CreatedById", "CreatedOn", "Email", "FullName", "IsActive", "LastLoggedInTime", "LoginSessionId", "MobileNo", "NickName", "Password", "UpdatedById", "UpdatedOn", "Username" },
                values: new object[] { 1L, null, new DateTime(2020, 6, 21, 22, 28, 28, 494, DateTimeKind.Utc).AddTicks(9758), "erandika1986@gmail.com", "SuperAdmin", true, null, null, "0702605650", "SuperAdmin", "HGnySkxIrdSxVCdICLWgVQxx", null, new DateTime(2020, 6, 21, 22, 28, 28, 495, DateTimeKind.Utc).AddTicks(390), "erandika1986@gmail.com" });

            migrationBuilder.InsertData(
                schema: "Account",
                table: "User",
                columns: new[] { "Id", "CreatedById", "CreatedOn", "Email", "FullName", "IsActive", "LastLoggedInTime", "LoginSessionId", "MobileNo", "NickName", "Password", "UpdatedById", "UpdatedOn", "Username" },
                values: new object[] { 2L, null, new DateTime(2020, 6, 21, 22, 28, 28, 495, DateTimeKind.Utc).AddTicks(2273), "erandika.du@gmail.com", "Admin", true, null, null, "0702605651", "Admin", "HGnySkxIrdSxVCdICLWgVQxx", null, new DateTime(2020, 6, 21, 22, 28, 28, 495, DateTimeKind.Utc).AddTicks(2282), "erandika.du@gmail.com" });

            migrationBuilder.InsertData(
                schema: "Account",
                table: "Role",
                columns: new[] { "Id", "CreatedById", "CreatedOn", "Description", "IsActive", "Name", "UpdatedById", "UpdatedOn" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTime(2020, 6, 21, 22, 28, 28, 503, DateTimeKind.Utc).AddTicks(9857), "SuperAdmin", true, "SuperAdmin", 1L, new DateTime(2020, 6, 21, 22, 28, 28, 504, DateTimeKind.Utc).AddTicks(1155) },
                    { 2L, 1L, new DateTime(2020, 6, 21, 22, 28, 28, 504, DateTimeKind.Utc).AddTicks(3954), "Admin", true, "Admin", 1L, new DateTime(2020, 6, 21, 22, 28, 28, 504, DateTimeKind.Utc).AddTicks(3969) },
                    { 3L, 1L, new DateTime(2020, 6, 21, 22, 28, 28, 504, DateTimeKind.Utc).AddTicks(4044), "Principle", true, "Principle", 1L, new DateTime(2020, 6, 21, 22, 28, 28, 504, DateTimeKind.Utc).AddTicks(4045) },
                    { 4L, 1L, new DateTime(2020, 6, 21, 22, 28, 28, 504, DateTimeKind.Utc).AddTicks(4046), "LevelHead", true, "LevelHead", 1L, new DateTime(2020, 6, 21, 22, 28, 28, 504, DateTimeKind.Utc).AddTicks(4046) },
                    { 5L, 1L, new DateTime(2020, 6, 21, 22, 28, 28, 504, DateTimeKind.Utc).AddTicks(4047), "HOD", true, "HOD", 1L, new DateTime(2020, 6, 21, 22, 28, 28, 504, DateTimeKind.Utc).AddTicks(4048) },
                    { 6L, 1L, new DateTime(2020, 6, 21, 22, 28, 28, 504, DateTimeKind.Utc).AddTicks(4049), "Teacher", true, "Teacher", 1L, new DateTime(2020, 6, 21, 22, 28, 28, 504, DateTimeKind.Utc).AddTicks(4049) },
                    { 7L, 1L, new DateTime(2020, 6, 21, 22, 28, 28, 504, DateTimeKind.Utc).AddTicks(4050), "Student", true, "Student", 1L, new DateTime(2020, 6, 21, 22, 28, 28, 504, DateTimeKind.Utc).AddTicks(4050) },
                    { 8L, 1L, new DateTime(2020, 6, 21, 22, 28, 28, 504, DateTimeKind.Utc).AddTicks(4051), "Parent", true, "Parent", 1L, new DateTime(2020, 6, 21, 22, 28, 28, 504, DateTimeKind.Utc).AddTicks(4052) }
                });

            migrationBuilder.InsertData(
                schema: "Account",
                table: "UserRole",
                columns: new[] { "UserId", "RoleId", "CreatedById", "CreatedOn", "IsActive", "UpdatedById", "UpdatedOn" },
                values: new object[] { 1L, 1L, 1L, new DateTime(2020, 6, 21, 22, 28, 28, 519, DateTimeKind.Utc).AddTicks(3301), true, 1L, new DateTime(2020, 6, 21, 22, 28, 28, 519, DateTimeKind.Utc).AddTicks(4108) });

            migrationBuilder.InsertData(
                schema: "Account",
                table: "UserRole",
                columns: new[] { "UserId", "RoleId", "CreatedById", "CreatedOn", "IsActive", "UpdatedById", "UpdatedOn" },
                values: new object[] { 2L, 2L, 1L, new DateTime(2020, 6, 21, 22, 28, 28, 519, DateTimeKind.Utc).AddTicks(7890), true, 1L, new DateTime(2020, 6, 21, 22, 28, 28, 519, DateTimeKind.Utc).AddTicks(7901) });

            migrationBuilder.CreateIndex(
                name: "IX_Role_CreatedById",
                schema: "Account",
                table: "Role",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Role_UpdatedById",
                schema: "Account",
                table: "Role",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_User_CreatedById",
                schema: "Account",
                table: "User",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_User_UpdatedById",
                schema: "Account",
                table: "User",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_CreatedById",
                schema: "Account",
                table: "UserRole",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_RoleId",
                schema: "Account",
                table: "UserRole",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_UpdatedById",
                schema: "Account",
                table: "UserRole",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_StudentSubjectScore_GradeId",
                schema: "Analysis",
                table: "StudentSubjectScore",
                column: "GradeId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentSubjectScore_StudentSubjectId",
                schema: "Analysis",
                table: "StudentSubjectScore",
                column: "StudentSubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_EssayAnswer_QuestonId",
                schema: "Lesson",
                table: "EssayAnswer",
                column: "QuestonId");

            migrationBuilder.CreateIndex(
                name: "IX_EssayStudentAnswer_QuestonId",
                schema: "Lesson",
                table: "EssayStudentAnswer",
                column: "QuestonId");

            migrationBuilder.CreateIndex(
                name: "IX_EssayStudentAnswer_StudentId",
                schema: "Lesson",
                table: "EssayStudentAnswer",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Lesson_CreatedById",
                schema: "Lesson",
                table: "Lesson",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Lesson_OwnerId",
                schema: "Lesson",
                table: "Lesson",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Lesson_UpdatedById",
                schema: "Lesson",
                table: "Lesson",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Lesson_SubjectId_AcademicLevelId",
                schema: "Lesson",
                table: "Lesson",
                columns: new[] { "SubjectId", "AcademicLevelId" });

            migrationBuilder.CreateIndex(
                name: "IX_Lesson_ClassNameId_AcademicLevelId_AcademicYearId",
                schema: "Lesson",
                table: "Lesson",
                columns: new[] { "ClassNameId", "AcademicLevelId", "AcademicYearId" });

            migrationBuilder.CreateIndex(
                name: "IX_LessonChat_FromUserId",
                schema: "Lesson",
                table: "LessonChat",
                column: "FromUserId");

            migrationBuilder.CreateIndex(
                name: "IX_LessonChat_LessonId",
                schema: "Lesson",
                table: "LessonChat",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_LessonChat_ToUserId",
                schema: "Lesson",
                table: "LessonChat",
                column: "ToUserId");

            migrationBuilder.CreateIndex(
                name: "IX_LessonChat_TopicId",
                schema: "Lesson",
                table: "LessonChat",
                column: "TopicId");

            migrationBuilder.CreateIndex(
                name: "IX_MCQAnswer_QuestonId",
                schema: "Lesson",
                table: "MCQAnswer",
                column: "QuestonId");

            migrationBuilder.CreateIndex(
                name: "IX_MCQStudentAnswer_StudentId_QuestionId",
                schema: "Lesson",
                table: "MCQStudentAnswer",
                columns: new[] { "StudentId", "QuestionId" });

            migrationBuilder.CreateIndex(
                name: "IX_MCQStudentQuestion_QuestionId",
                schema: "Lesson",
                table: "MCQStudentQuestion",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Question_LessonId",
                schema: "Lesson",
                table: "Question",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_Question_TopicId",
                schema: "Lesson",
                table: "Question",
                column: "TopicId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentLesson_LessonId",
                schema: "Lesson",
                table: "StudentLesson",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentTopic_TopicId",
                schema: "Lesson",
                table: "StudentTopic",
                column: "TopicId");

            migrationBuilder.CreateIndex(
                name: "IX_Topic_LessonId",
                schema: "Lesson",
                table: "Topic",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_TopicContent_TopicId",
                schema: "Lesson",
                table: "TopicContent",
                column: "TopicId");

            migrationBuilder.CreateIndex(
                name: "IX_AcademicLevel_CreatedById",
                schema: "Master",
                table: "AcademicLevel",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_AcademicLevel_LevelHeadId",
                schema: "Master",
                table: "AcademicLevel",
                column: "LevelHeadId");

            migrationBuilder.CreateIndex(
                name: "IX_AcademicLevel_UpdatedById",
                schema: "Master",
                table: "AcademicLevel",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_AcademicYear_CreatedById",
                schema: "Master",
                table: "AcademicYear",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_AcademicYear_UpdatedById",
                schema: "Master",
                table: "AcademicYear",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_AssessmentType_CreatedById",
                schema: "Master",
                table: "AssessmentType",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_AssessmentType_UpdatedById",
                schema: "Master",
                table: "AssessmentType",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_AssessmentTypeAcademicLevel_AcademicLevelId",
                schema: "Master",
                table: "AssessmentTypeAcademicLevel",
                column: "AcademicLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_AssessmentTypeAcademicLevel_CreatedById",
                schema: "Master",
                table: "AssessmentTypeAcademicLevel",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_AssessmentTypeAcademicLevel_UpdatedById",
                schema: "Master",
                table: "AssessmentTypeAcademicLevel",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Class_AcademicLevelId",
                schema: "Master",
                table: "Class",
                column: "AcademicLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_Class_AcademicYearId",
                schema: "Master",
                table: "Class",
                column: "AcademicYearId");

            migrationBuilder.CreateIndex(
                name: "IX_Class_CreatedById",
                schema: "Master",
                table: "Class",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Class_UpdatedById",
                schema: "Master",
                table: "Class",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ClassName_CreatedById",
                schema: "Master",
                table: "ClassName",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ClassName_UpdatedById",
                schema: "Master",
                table: "ClassName",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ClassSubjectTeacher_CreatedById",
                schema: "Master",
                table: "ClassSubjectTeacher",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ClassSubjectTeacher_SubjectTeacherId",
                schema: "Master",
                table: "ClassSubjectTeacher",
                column: "SubjectTeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassSubjectTeacher_UpdatedById",
                schema: "Master",
                table: "ClassSubjectTeacher",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ClassSubjectTeacher_SubjectId_AcademicLevelId",
                schema: "Master",
                table: "ClassSubjectTeacher",
                columns: new[] { "SubjectId", "AcademicLevelId" });

            migrationBuilder.CreateIndex(
                name: "IX_ClassSubjectTeacher_ClassNameId_AcademicLevelId_AcademicYearId",
                schema: "Master",
                table: "ClassSubjectTeacher",
                columns: new[] { "ClassNameId", "AcademicLevelId", "AcademicYearId" });

            migrationBuilder.CreateIndex(
                name: "IX_ClassTeacher_CreatedById",
                schema: "Master",
                table: "ClassTeacher",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ClassTeacher_TeacherId",
                schema: "Master",
                table: "ClassTeacher",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassTeacher_UpdatedById",
                schema: "Master",
                table: "ClassTeacher",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ClassTimeTablePeriod_CreatedById",
                schema: "Master",
                table: "ClassTimeTablePeriod",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ClassTimeTablePeriod_DayId",
                schema: "Master",
                table: "ClassTimeTablePeriod",
                column: "DayId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassTimeTablePeriod_PeriodId",
                schema: "Master",
                table: "ClassTimeTablePeriod",
                column: "PeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassTimeTablePeriod_UpdatedById",
                schema: "Master",
                table: "ClassTimeTablePeriod",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ClassTimeTablePeriod_SubjectId_AcademicLevelId",
                schema: "Master",
                table: "ClassTimeTablePeriod",
                columns: new[] { "SubjectId", "AcademicLevelId" });

            migrationBuilder.CreateIndex(
                name: "IX_ClassTimeTablePeriod_ClassNameId_AcademicLevelId_AcademicYearId",
                schema: "Master",
                table: "ClassTimeTablePeriod",
                columns: new[] { "ClassNameId", "AcademicLevelId", "AcademicYearId" });

            migrationBuilder.CreateIndex(
                name: "IX_ClassTimeTablePeriodAssignTeacher_ClassTimeTablePeriodId",
                schema: "Master",
                table: "ClassTimeTablePeriodAssignTeacher",
                column: "ClassTimeTablePeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassTimeTablePeriodAssignTeacher_CreatedById",
                schema: "Master",
                table: "ClassTimeTablePeriodAssignTeacher",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ClassTimeTablePeriodAssignTeacher_TeacherId",
                schema: "Master",
                table: "ClassTimeTablePeriodAssignTeacher",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassTimeTablePeriodAssignTeacher_UpdatedById",
                schema: "Master",
                table: "ClassTimeTablePeriodAssignTeacher",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Day_CreatedById",
                schema: "Master",
                table: "Day",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Day_UpdatedById",
                schema: "Master",
                table: "Day",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_HeadOfDepartment_AcademicLevelId",
                schema: "Master",
                table: "HeadOfDepartment",
                column: "AcademicLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_HeadOfDepartment_AcademicYearId",
                schema: "Master",
                table: "HeadOfDepartment",
                column: "AcademicYearId");

            migrationBuilder.CreateIndex(
                name: "IX_HeadOfDepartment_CreatedById",
                schema: "Master",
                table: "HeadOfDepartment",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_HeadOfDepartment_SubjectId",
                schema: "Master",
                table: "HeadOfDepartment",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_HeadOfDepartment_TeacherId",
                schema: "Master",
                table: "HeadOfDepartment",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_HeadOfDepartment_UpdatedById",
                schema: "Master",
                table: "HeadOfDepartment",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_HeadOfDepartment_SubjectAcademicLevelSubjectId_SubjectAcademicLevelAcademicLevelId",
                schema: "Master",
                table: "HeadOfDepartment",
                columns: new[] { "SubjectAcademicLevelSubjectId", "SubjectAcademicLevelAcademicLevelId" });

            migrationBuilder.CreateIndex(
                name: "IX_LockingDate_AcademicLevelId",
                schema: "Master",
                table: "LockingDate",
                column: "AcademicLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_LockingDate_AssessmentTypeId",
                schema: "Master",
                table: "LockingDate",
                column: "AssessmentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_LockingDate_CreatedById",
                schema: "Master",
                table: "LockingDate",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_LockingDate_SubjectId",
                schema: "Master",
                table: "LockingDate",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_LockingDate_UpdatedById",
                schema: "Master",
                table: "LockingDate",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Period_CreatedById",
                schema: "Master",
                table: "Period",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Period_UpdatedById",
                schema: "Master",
                table: "Period",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Student_CreatedById",
                schema: "Master",
                table: "Student",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Student_UpdatedById",
                schema: "Master",
                table: "Student",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_StudentClass_CreatedById",
                schema: "Master",
                table: "StudentClass",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_StudentClass_StudentId",
                schema: "Master",
                table: "StudentClass",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentClass_UpdatedById",
                schema: "Master",
                table: "StudentClass",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_StudentClass_ClassNameId_AcademicLevelId_AcademicYearId",
                schema: "Master",
                table: "StudentClass",
                columns: new[] { "ClassNameId", "AcademicLevelId", "AcademicYearId" });

            migrationBuilder.CreateIndex(
                name: "IX_StudentSubject_AcademicLevelId",
                schema: "Master",
                table: "StudentSubject",
                column: "AcademicLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentSubject_AcademicYearId",
                schema: "Master",
                table: "StudentSubject",
                column: "AcademicYearId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentSubject_CreatedById",
                schema: "Master",
                table: "StudentSubject",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_StudentSubject_StudentId",
                schema: "Master",
                table: "StudentSubject",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentSubject_UpdatedById",
                schema: "Master",
                table: "StudentSubject",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_StudentSubject_SubjectId_AcademicLevelId",
                schema: "Master",
                table: "StudentSubject",
                columns: new[] { "SubjectId", "AcademicLevelId" });

            migrationBuilder.CreateIndex(
                name: "IX_Subject_CreatedById",
                schema: "Master",
                table: "Subject",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Subject_ParentBasketSubjectId",
                schema: "Master",
                table: "Subject",
                column: "ParentBasketSubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Subject_UpdatedById",
                schema: "Master",
                table: "Subject",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectAcademicLevel_AcademicLevelId",
                schema: "Master",
                table: "SubjectAcademicLevel",
                column: "AcademicLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectAcademicLevel_CreatedById",
                schema: "Master",
                table: "SubjectAcademicLevel",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectAcademicLevel_UpdatedById",
                schema: "Master",
                table: "SubjectAcademicLevel",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectTeacher_AcademicYearId",
                schema: "Master",
                table: "SubjectTeacher",
                column: "AcademicYearId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectTeacher_CreatedById",
                schema: "Master",
                table: "SubjectTeacher",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectTeacher_TeacherId",
                schema: "Master",
                table: "SubjectTeacher",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectTeacher_UpdatedById",
                schema: "Master",
                table: "SubjectTeacher",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectTeacher_SubjectId_AcademicLevelId",
                schema: "Master",
                table: "SubjectTeacher",
                columns: new[] { "SubjectId", "AcademicLevelId" });

            migrationBuilder.CreateIndex(
                name: "IX_SubjectTeacher_ClassNameId_ClassAcademicLevelId_ClassAcademicYearId",
                schema: "Master",
                table: "SubjectTeacher",
                columns: new[] { "ClassNameId", "ClassAcademicLevelId", "ClassAcademicYearId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserRole",
                schema: "Account");

            migrationBuilder.DropTable(
                name: "StudentSubjectScore",
                schema: "Analysis");

            migrationBuilder.DropTable(
                name: "EssayAnswer",
                schema: "Lesson");

            migrationBuilder.DropTable(
                name: "EssayStudentAnswer",
                schema: "Lesson");

            migrationBuilder.DropTable(
                name: "LessonChat",
                schema: "Lesson");

            migrationBuilder.DropTable(
                name: "MCQStudentAnswer",
                schema: "Lesson");

            migrationBuilder.DropTable(
                name: "StudentLesson",
                schema: "Lesson");

            migrationBuilder.DropTable(
                name: "StudentTopic",
                schema: "Lesson");

            migrationBuilder.DropTable(
                name: "TopicContent",
                schema: "Lesson");

            migrationBuilder.DropTable(
                name: "AssessmentTypeAcademicLevel",
                schema: "Master");

            migrationBuilder.DropTable(
                name: "ClassSubjectTeacher",
                schema: "Master");

            migrationBuilder.DropTable(
                name: "ClassTeacher",
                schema: "Master");

            migrationBuilder.DropTable(
                name: "ClassTimeTablePeriodAssignTeacher",
                schema: "Master");

            migrationBuilder.DropTable(
                name: "HeadOfDepartment",
                schema: "Master");

            migrationBuilder.DropTable(
                name: "LockingDate",
                schema: "Master");

            migrationBuilder.DropTable(
                name: "StudentClass",
                schema: "Master");

            migrationBuilder.DropTable(
                name: "Role",
                schema: "Account");

            migrationBuilder.DropTable(
                name: "Grade",
                schema: "Analysis");

            migrationBuilder.DropTable(
                name: "StudentSubject",
                schema: "Master");

            migrationBuilder.DropTable(
                name: "MCQAnswer",
                schema: "Lesson");

            migrationBuilder.DropTable(
                name: "MCQStudentQuestion",
                schema: "Lesson");

            migrationBuilder.DropTable(
                name: "SubjectTeacher",
                schema: "Master");

            migrationBuilder.DropTable(
                name: "ClassTimeTablePeriod",
                schema: "Master");

            migrationBuilder.DropTable(
                name: "AssessmentType",
                schema: "Master");

            migrationBuilder.DropTable(
                name: "Student",
                schema: "Master");

            migrationBuilder.DropTable(
                name: "Question",
                schema: "Lesson");

            migrationBuilder.DropTable(
                name: "Day",
                schema: "Master");

            migrationBuilder.DropTable(
                name: "Period",
                schema: "Master");

            migrationBuilder.DropTable(
                name: "Topic",
                schema: "Lesson");

            migrationBuilder.DropTable(
                name: "Lesson",
                schema: "Lesson");

            migrationBuilder.DropTable(
                name: "SubjectAcademicLevel",
                schema: "Master");

            migrationBuilder.DropTable(
                name: "Class",
                schema: "Master");

            migrationBuilder.DropTable(
                name: "Subject",
                schema: "Master");

            migrationBuilder.DropTable(
                name: "AcademicLevel",
                schema: "Master");

            migrationBuilder.DropTable(
                name: "AcademicYear",
                schema: "Master");

            migrationBuilder.DropTable(
                name: "ClassName",
                schema: "Master");

            migrationBuilder.DropTable(
                name: "User",
                schema: "Account");
        }
    }
}
