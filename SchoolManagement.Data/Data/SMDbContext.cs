using Microsoft.EntityFrameworkCore;
using SchoolManagement.Data.Configurations;
using SchoolManagement.Model;
using SchoolManagement.Util;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Data
{
    public class SMDbContext : DbContext
    {
        private Tenant _tenant;

        public SMDbContext()
        {

        }

        public SMDbContext(DbContextOptions<SMDbContext> options, ITenantProvider tenantProvider) : base(options)
        {
            GetTenant(tenantProvider).Wait();
        }

        public async Task GetTenant(ITenantProvider tenantProvider)
        {
            _tenant = await tenantProvider.GetTenant();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(_tenant!=null)
            {
                optionsBuilder.UseSqlServer(_tenant.ConnectionString);
            }
            else
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-4B3H53F;Database=SMDB;Trusted_Connection=True;User Id=sa1;Password=1qaz2wsx@;");
            }

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //For Account Entities
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new UserRoleConfiguration());

            //For Analysis Entities
            modelBuilder.ApplyConfiguration(new GradeConfiguration());
            modelBuilder.ApplyConfiguration(new StudentSubjectScoreConfiguration());

            //For Master Entities
            modelBuilder.ApplyConfiguration(new AcademicLevelConfiguration());
            modelBuilder.ApplyConfiguration(new AcademicYearConfiguration());
            modelBuilder.ApplyConfiguration(new AssessmentTypeAcademicLevelConfiguration());
            modelBuilder.ApplyConfiguration(new AssessmentTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ClassConfiguration());
            modelBuilder.ApplyConfiguration(new ClassNameConfiguration());
            modelBuilder.ApplyConfiguration(new ClassSubjectTeacherConfiguration());
            modelBuilder.ApplyConfiguration(new ClassTeacherConfiguration());

            modelBuilder.ApplyConfiguration(new DayConfiguration());
            modelBuilder.ApplyConfiguration(new HeadOfDepartmentConfiguration());
            modelBuilder.ApplyConfiguration(new LockingDateConfiguration());
            modelBuilder.ApplyConfiguration(new PeriodConfiguration());
            modelBuilder.ApplyConfiguration(new StudentClassConfiguration());
            modelBuilder.ApplyConfiguration(new StudentConfiguration());
            modelBuilder.ApplyConfiguration(new StudentSubjectConfiguration());
            modelBuilder.ApplyConfiguration(new SubjectAcademicLevelConfiguration());
            modelBuilder.ApplyConfiguration(new SubjectConfiguration());
            //modelBuilder.ApplyConfiguration(new BasketSubjectConfiguration());
            modelBuilder.ApplyConfiguration(new SubjectTeacherConfiguration());

            // For TimeTable Entities
            modelBuilder.ApplyConfiguration(new TimeTableConfiguration());
            modelBuilder.ApplyConfiguration(new ClassTimeTablePeriodAssignTeacherConfiguration());
            modelBuilder.ApplyConfiguration(new ClassTimeTablePeriodConfiguration());

            //Lesson Entities
            modelBuilder.ApplyConfiguration(new LessonConfiguration());
            modelBuilder.ApplyConfiguration(new TopicConfiguration());
            modelBuilder.ApplyConfiguration(new TopicContentConfiguration());
            modelBuilder.ApplyConfiguration(new QuestionConfiguration());
            modelBuilder.ApplyConfiguration(new EssayAnswerConfiguration());
            modelBuilder.ApplyConfiguration(new MCQAnswerConfiguration());
            modelBuilder.ApplyConfiguration(new EssayStudentAnswerConfiguration());
            modelBuilder.ApplyConfiguration(new MCQStudentQuestionConfiguration());
            modelBuilder.ApplyConfiguration(new MCQStudentAnswerConfiguration());
            modelBuilder.ApplyConfiguration(new LessonChatConfiguration());
            modelBuilder.ApplyConfiguration(new StudentLessonConfiguration());
            modelBuilder.ApplyConfiguration(new StudentTopicConfiguraton());

            base.OnModelCreating(modelBuilder);
        }

        //Account Entities
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        //Master Entities
        public DbSet<AcademicLevel> AcademicLevels { get; set; }
        public DbSet<AcademicYear> AcademicYears { get; set; }
        public DbSet<AssessmentType> AssessmentTypes { get; set; }
        public DbSet<AssessmentTypeAcademicLevel> AssessmentTypeAcademicLevels { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<ClassName> ClassNames { get; set; }
        public DbSet<ClassSubjectTeacher> ClassSubjectTeachers { get; set; }
        public DbSet<ClassTeacher> ClassTeachers { get; set; }
        public DbSet<Day> Days { get; set; }
        public DbSet<HeadOfDepartment> HeadOfDepartments { get; set; }
        public DbSet<LockingDate> LockingDates { get; set; }
        public DbSet<Period> Periods { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentClass> StudentClasses { get; set; }
        public DbSet<StudentSubject> StudentSubjects { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        //public DbSet<BasketSubject> BasketSubjects { get; set; }
        public DbSet<SubjectAcademicLevel> SubjectAcademicLevels { get; set; }
        public DbSet<SubjectTeacher> SubjectTeachers { get; set; }

        //TimeTable Entities
        public DbSet<TimeTable> TimeTables { get; set; }
        public DbSet<ClassTimeTablePeriod> ClassTimeTablePeriods { get; set; }
        public DbSet<ClassTimeTablePeriodAssignTeacher> ClassTimeTablePeriodAssignTeachers { get; set; }

        //Analysis Entities
        public DbSet<Grade> Grades { get; set; }
        public DbSet<StudentSubjectScore> StudentSubjectScores { get; set; }

        //Lesson Entities
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<TopicContent> TopicContents { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<EssayAnswer> EssayAnswers { get; set; }
        public DbSet<MCQAnswer> MCQAnswers { get; set; }
        public DbSet<EssayStudentAnswer> EssayStudentAnswers { get; set; }
        public DbSet<MCQStudentQuestion> MCQStudentQuestions { get; set; }
        public DbSet<MCQStudentAnswer> MCQStudentAnswers { get; set; }
        public DbSet<LessonChat> LessonChats { get; set; }
        public DbSet<StudentLesson> StudentLessons { get; set; }
        public DbSet<StudentTopic> StudentTopics { get; set; }

    }
}
