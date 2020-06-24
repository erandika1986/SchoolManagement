using SchoolManagement.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Data
{
    public interface ISMUow
    {
        void Commit();
        Task<int> CommitAsync();

        IRepository<User> Users { get; }
        IRepository<Role> Roles { get; }
        IRepository<UserRole> UserRoles { get; }

        IRepository<Grade> Grades { get; }
        IRepository<StudentSubjectScore> StudentSubjectScores { get; }

        IRepository<AcademicLevel> AcademicLevels { get; }
        IRepository<AcademicYear> AcademicYears { get; }
        IRepository<AssessmentType> AssessmentTypes { get; }
        IRepository<AssessmentTypeAcademicLevel> AssessmentTypeAcademicLevels { get; }
        IRepository<Class> Classes { get; }
        IRepository<ClassName> ClassNames { get; }
        IRepository<ClassSubjectTeacher> ClassSubjectTeachers { get; }
        IRepository<ClassTeacher> ClassTeachers { get; }
        IRepository<ClassTimeTablePeriod> ClassTimeTablePeriods { get; }
        IRepository<ClassTimeTablePeriodAssignTeacher> ClassTimeTablePeriodAssignTeachers { get; }
        IRepository<Day> Days { get; }
        IRepository<HeadOfDepartment> HeadOfDepartments { get; }
        IRepository<LockingDate> LockingDates { get; }
        IRepository<Period> Periods { get; }
        IRepository<Student> Students { get; }
        IRepository<StudentClass> StudentClasses { get; }
        IRepository<StudentSubject> StudentSubjects { get; }
        IRepository<Subject> Subjects { get; }
        //IRepository<BasketSubject> BasketSubjects { get; }
        IRepository<SubjectAcademicLevel> SubjectAcademicLevels { get; }
        IRepository<SubjectTeacher> SubjectTeachers { get; }


        IRepository<Lesson> Lessons { get; }
        IRepository<Topic> Topics { get; }
        IRepository<TopicContent> TopicContents { get; }
        IRepository<Question> Questions { get; }
        IRepository<EssayAnswer> EssayAnswers { get; }
        IRepository<MCQAnswer> MCQAnswers { get; }
        IRepository<EssayStudentAnswer> EssayStudentAnswers { get; }
        IRepository<MCQStudentQuestion> MCQStudentQuestions { get; }
        IRepository<MCQStudentAnswer> MCQStudentAnswers { get; }
    }
}
