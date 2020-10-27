using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Model
{
    public class User
    {
        public long Id { get; set; }
        public string FullName { get; set; }
        public string NickName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string MobileNo { get; set; }
        public string Password { get; set; }
        public DateTime? LastLoggedInTime { get; set; }
        public string LoginSessionId { get; set; }

        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public long? CreatedById { get; set; }
        public DateTime UpdatedOn { get; set; }
        public long? UpdatedById { get; set; }

        public virtual User CreatedBy { get; set; }
        public virtual User UpdatedBy { get; set; }

        public virtual ICollection<UserRole> UserRoles { get; set; }
        public virtual ICollection<SubjectTeacher> SubjectTeachers { get; set; }
        public virtual ICollection<ClassTeacher> ClassTeachers { get; set; }
        public virtual ICollection<HeadOfDepartment> HeadOfDepartments { get; set; }

        public virtual ICollection<ClassTimeTablePeriodAssignTeacher> ClassTimeTablePeriodAssignTeachers { get; set; }


        #region Navigation Properties for Account Entities

        public virtual ICollection<Role> CreatedRoles { get; set; }
        public virtual ICollection<Role> UpdatedRoles { get; set; }

        public virtual ICollection<User> CreatedUsers { get; set; }
        public virtual ICollection<User> UpdatedUsers { get; set; }


        public virtual ICollection<UserRole> CreatedUserRoles { get; set; }
        public virtual ICollection<UserRole> UpdatedUserRoles { get; set; }

        #endregion

        #region Navigation Properties for Master Entities

        public virtual ICollection<AcademicLevel> CreatedAcademicLevels { get; set; }
        public virtual ICollection<AcademicLevel> UpdatedAcademicLevels { get; set; }

        public virtual ICollection<AcademicYear> CreatedAcademicYears { get; set; }
        public virtual ICollection<AcademicYear> UpdatedAcademicYears { get; set; }

        public virtual ICollection<AssessmentType> CreatedAssessmentTypes { get; set; }
        public virtual ICollection<AssessmentType> UpdatedAssessmentTypes { get; set; }

        public virtual ICollection<AssessmentTypeAcademicLevel> CreatedAssessmentTypeAcademicLevels { get; set; }
        public virtual ICollection<AssessmentTypeAcademicLevel> UpdatedAssessmentTypeAcademicLevels { get; set; }
        public virtual ICollection<SubjectAcademicLevel> CreatedSubjectAcademicLevels { get; set; }
        public virtual ICollection<SubjectAcademicLevel> UpdatedSubjectAcademicLevels { get; set; }

        public virtual ICollection<Class> CreatedClasses { get; set; }
        public virtual ICollection<Class> UpdatedClasses { get; set; }

        public virtual ICollection<ClassName> CreatedClassNames { get; set; }
        public virtual ICollection<ClassName> UpdatedClassNames { get; set; }

        public virtual ICollection<ClassSubjectTeacher> CreatedClassSubjectTeachers { get; set; }
        public virtual ICollection<ClassSubjectTeacher> UpdatedClassSubjectTeachers { get; set; }

        public virtual ICollection<ClassTeacher> CreatedClassTeachers { get; set; }
        public virtual ICollection<ClassTeacher> UpdatedClassTeachers { get; set; }



        public virtual ICollection<Day> CreatedDays { get; set; }
        public virtual ICollection<Day> UpdatedDays { get; set; }

        public virtual ICollection<HeadOfDepartment> CreatedHeadOfDepartments { get; set; }
        public virtual ICollection<HeadOfDepartment> UpdatedHeadOfDepartments { get; set; }

        public virtual ICollection<LockingDate> CreatedLockingDates { get; set; }
        public virtual ICollection<LockingDate> UpdatedLockingDates { get; set; }

        public virtual ICollection<Period> CreatedPeriods { get; set; }
        public virtual ICollection<Period> UpdatedPeriods { get; set; }

        public virtual ICollection<Student> CreatedStudents { get; set; }
        public virtual ICollection<Student> UpdatedStudents { get; set; }

        public virtual ICollection<StudentClass> CreatedStudentClasses { get; set; }
        public virtual ICollection<StudentClass> UpdatedStudentClasses { get; set; }

        public virtual ICollection<StudentSubject> CreatedStudentSubjects { get; set; }
        public virtual ICollection<StudentSubject> UpdatedStudentSubjects { get; set; }

        public virtual ICollection<Subject> CreatedSubjects { get; set; }
        public virtual ICollection<Subject> UpdatedSubjects { get; set; }

        public virtual ICollection<SubjectTeacher> CreatedSubjectTeachers { get; set; }
        public virtual ICollection<SubjectTeacher> UpdatedSubjectTeachers { get; set; }


        #endregion

        #region Navigation Properties for TimeTable Entities

        public virtual ICollection<TimeTable> CreatedTimeTables { get; set; }
        public virtual ICollection<TimeTable> UpdatedTimeTables { get; set; }

        public virtual ICollection<ClassTimeTablePeriod> CreatedClassTimeTablePeriods { get; set; }
        public virtual ICollection<ClassTimeTablePeriod> UpdatedClassTimeTablePeriods { get; set; }

        public virtual ICollection<ClassTimeTablePeriodAssignTeacher> CreatedClassTimeTablePeriodAssignTeachers { get; set; }
        public virtual ICollection<ClassTimeTablePeriodAssignTeacher> UpdatedClassTimeTablePeriodAssignTeachers { get; set; }

        #endregion


        #region Navigation Properties for Lesson Entities

        public virtual ICollection<Lesson> CreatedLessons { get; set; }
        public virtual ICollection<Lesson> UpdatedLessons { get; set; }
        public virtual ICollection<Lesson> OwnerLessons { get; set; }

        public virtual ICollection<EssayStudentAnswer> EssayStudentAnswers { get; set; }
        public virtual ICollection<MCQStudentQuestion> MCQStudentQuestions { get; set; }

        public virtual ICollection<StudentTopic> StudentTopics { get; set; }
        public virtual ICollection<StudentLesson> StudentLessons { get; set; }

        public virtual ICollection<LessonChat> LessonChatsFrom { get; set; }
        public virtual ICollection<LessonChat> LessonChatsTo { get; set; }

        #endregion
    }
}
