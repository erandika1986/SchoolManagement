using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Model
{
    public class AcademicLevel
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public long LevelHeadId { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public long CreatedById { get; set; }
        public DateTime UpdatedOn { get; set; }
        public long UpdatedById { get; set; }

        public virtual User CreatedBy { get; set; }
        public virtual User UpdatedBy { get; set; }
        public virtual User LevelHead { get; set; }


        public virtual ICollection<SubjectAcademicLevel> SubjectAcademicLevels { get; set; }
        public virtual ICollection<Class> Classes { get; set; }
        public virtual ICollection<HeadOfDepartment> HeadOfDepartments { get; set; }
        public virtual ICollection<StudentSubject> StudentSubjects { get; set; }
        public virtual ICollection<AssessmentTypeAcademicLevel> AssessmentTypeAcademicLevels { get; set; }
        public virtual ICollection<LockingDate> LockingDates { get; set; }
    }
}
