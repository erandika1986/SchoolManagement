using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Model
{
    public class SubjectAcademicLevel
    {
        public long SubjectId { get; set; }
        public long AcademicLevelId { get; set; }
        public int NoOfPeriodPerWeek { get; set; }

        public virtual Subject Subject { get; set; }
        public virtual AcademicLevel AcademicLevel { get; set; }

        public DateTime CreatedOn { get; set; }
        public long? CreatedById { get; set; }
        public DateTime UpdatedOn { get; set; }
        public long? UpdatedById { get; set; }

        public virtual User CreatedBy { get; set; }
        public virtual User UpdatedBy { get; set; }


        public virtual ICollection<HeadOfDepartment> HeadOfDepartments { get; set; }
        public virtual ICollection<ClassTimeTablePeriod> ClassTimeTablePeriods { get; set; }
        public virtual ICollection<StudentSubject> StudentSubjects { get; set; }
        public virtual ICollection<SubjectTeacher> SubjectTeachers { get; set; }
        public virtual ICollection<ClassSubjectTeacher> ClassSubjectTeachers { get; set; }
        public virtual ICollection<Lesson> Lessons { get; set; }
    }
}
