using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SchoolManagement.Model;

namespace SchoolManagement.Data
{
    public class SMUow : ISMUow
    {
        #region Member Variables

        private IRepositoryProvider repositoryProvider;
        private SMDbContext dbContext;

        #endregion

        #region Constructor

        public SMUow(SMDbContext vMDBContext)
        {
            dbContext = vMDBContext;
            //dbContext.Database.Migrate();
            this.repositoryProvider = new RepositoryProvider(dbContext, new RepositoryFactories());
        }

        #endregion

        public IRepository<User> Users { get { return GetRepositoryByModel<User>(); } }

        public IRepository<Role> Roles { get { return GetRepositoryByModel<Role>(); } }

        public IRepository<UserRole> UserRoles { get { return GetRepositoryByModel<UserRole>(); } }

        public IRepository<Grade> Grades { get { return GetRepositoryByModel<Grade>(); } }

        public IRepository<StudentSubjectScore> StudentSubjectScores { get { return GetRepositoryByModel<StudentSubjectScore>(); } }

        public IRepository<AcademicLevel> AcademicLevels { get { return GetRepositoryByModel<AcademicLevel>(); } }

        public IRepository<AcademicYear> AcademicYears { get { return GetRepositoryByModel<AcademicYear>(); } }

        public IRepository<AssessmentType> AssessmentTypes { get { return GetRepositoryByModel<AssessmentType>(); } }

        public IRepository<AssessmentTypeAcademicLevel> AssessmentTypeAcademicLevels { get { return GetRepositoryByModel<AssessmentTypeAcademicLevel>(); } }

        public IRepository<Class> Classes { get { return GetRepositoryByModel<Class>(); } }

        public IRepository<ClassName> ClassNames { get { return GetRepositoryByModel<ClassName>(); } }

        public IRepository<ClassSubjectTeacher> ClassSubjectTeachers { get { return GetRepositoryByModel<ClassSubjectTeacher>(); } }

        public IRepository<ClassTeacher> ClassTeachers { get { return GetRepositoryByModel<ClassTeacher>(); } }

        public IRepository<TimeTable> TimeTables { get { return GetRepositoryByModel<TimeTable>(); } }

        public IRepository<ClassTimeTablePeriod> ClassTimeTablePeriods { get { return GetRepositoryByModel<ClassTimeTablePeriod>(); } }

        public IRepository<ClassTimeTablePeriodAssignTeacher> ClassTimeTablePeriodAssignTeachers { get { return GetRepositoryByModel<ClassTimeTablePeriodAssignTeacher>(); } }

        public IRepository<Day> Days { get { return GetRepositoryByModel<Day>(); } }

        public IRepository<HeadOfDepartment> HeadOfDepartments { get { return GetRepositoryByModel<HeadOfDepartment>(); } }

        public IRepository<LockingDate> LockingDates { get { return GetRepositoryByModel<LockingDate>(); } }

        public IRepository<Period> Periods { get { return GetRepositoryByModel<Period>(); } }

        public IRepository<Student> Students { get { return GetRepositoryByModel<Student>(); } }

        public IRepository<StudentClass> StudentClasses { get { return GetRepositoryByModel<StudentClass>(); } }

        public IRepository<StudentSubject> StudentSubjects { get { return GetRepositoryByModel<StudentSubject>(); } }

        public IRepository<Subject> Subjects { get { return GetRepositoryByModel<Subject>(); } }

        public IRepository<SubjectAcademicLevel> SubjectAcademicLevels { get { return GetRepositoryByModel<SubjectAcademicLevel>(); } }

        public IRepository<SubjectTeacher> SubjectTeachers { get { return GetRepositoryByModel<SubjectTeacher>(); } }



        public IRepository<Lesson> Lessons { get { return GetRepositoryByModel<Lesson>(); } }

        public IRepository<Topic> Topics { get { return GetRepositoryByModel<Topic>(); } }

        public IRepository<TopicContent> TopicContents { get { return GetRepositoryByModel<TopicContent>(); } }

        public IRepository<Question> Questions { get { return GetRepositoryByModel<Question>(); } }

        public IRepository<EssayAnswer> EssayAnswers { get { return GetRepositoryByModel<EssayAnswer>(); } }

        public IRepository<MCQAnswer> MCQAnswers { get { return GetRepositoryByModel<MCQAnswer>(); } }

        public IRepository<EssayStudentAnswer> EssayStudentAnswers { get { return GetRepositoryByModel<EssayStudentAnswer>(); } }

        public IRepository<MCQStudentQuestion> MCQStudentQuestions { get { return GetRepositoryByModel<MCQStudentQuestion>(); } }

        public IRepository<MCQStudentAnswer> MCQStudentAnswers { get { return GetRepositoryByModel<MCQStudentAnswer>(); } }

        //public IRepository<BasketSubject> BasketSubjects { get { return GetRepositoryByModel<BasketSubject>(); } }

        public void Commit()
        {
            dbContext.SaveChanges();
        }

        public async Task<int> CommitAsync()
        {
            return  await dbContext.SaveChangesAsync();
        }

        #region Private Methods

        private IRepository<T> GetRepositoryByModel<T>() where T : class
        {
            return repositoryProvider.GetRepositoryByEntity<T>();
        }

        private T GetRepositoryByRepository<T>() where T : class
        {
            return repositoryProvider.GetRepositoryByRepository<T>();
        }



        #endregion
    }
}
