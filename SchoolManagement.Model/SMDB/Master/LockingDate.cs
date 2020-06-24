using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Model
{
    public class LockingDate
    {
        public long AcademicYearId { get; set; }
        public long AcademicLevelId { get; set; }
        public long SubjectId { get; set; }
        public long AssessmentTypeId { get; set; }
        public Nullable<DateTime> TOSLockingDate { get; set; }
        public Nullable<DateTime> ResultLockingDate { get; set; }
        public bool HasExam { get; set; }
        public bool IsResultMigrated { get; set; }
        public Nullable<DateTime> MigratedDate { get; set; }

        public virtual AcademicYear AcademicYear { get; set; }
        public virtual AcademicLevel AcademicLevel { get; set; }
        public virtual Subject Subject { get; set; }
        public virtual AssessmentType AssessmentType { get; set; }

        public DateTime CreatedOn { get; set; }
        public long CreatedById { get; set; }
        public DateTime UpdatedOn { get; set; }
        public long UpdatedById { get; set; }

        public virtual User CreatedBy { get; set; }
        public virtual User UpdatedBy { get; set; }
    }
}
