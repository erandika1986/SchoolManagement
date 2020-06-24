using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Model
{
    public class Class
    {
        public long ClassNameId { get; set; }
        public long AcademicLevelId { get; set; }
        public long AcademicYearId { get; set; }
        public string Name { get; set; }

        public virtual ClassName ClassName { get; set; }
        public virtual AcademicLevel AcademicLevel { get; set; }
        public virtual AcademicYear AcademicYear { get; set; }

        public DateTime CreatedOn { get; set; }
        public long CreatedById { get; set; }
        public DateTime UpdatedOn { get; set; }
        public long UpdatedById { get; set; }

        public virtual User CreatedBy { get; set; }
        public virtual User UpdatedBy { get; set; }


        public virtual ICollection<ClassTeacher> ClassTeachers { get; set; }
        public virtual ICollection<SubjectTeacher> SubjectTeachers { get; set; }
        public virtual ICollection<StudentClass> StudentClasses { get; set; }
        public virtual ICollection<ClassSubjectTeacher> ClassSubjectTeachers { get; set; }
        public virtual ICollection<ClassTimeTablePeriod> ClassTimeTablePeriods { get; set; }
        public virtual ICollection<Lesson> Lessons { get; set; }
    }
}
