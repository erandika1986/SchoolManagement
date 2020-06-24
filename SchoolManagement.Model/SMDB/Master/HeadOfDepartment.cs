using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Model
{
    public class HeadOfDepartment
    {
        public long Id { get; set; }
        public long AcademicYearId { get; set; }
        public long AcademicLevelId { get; set; }
        public long SubjectId { get; set; }
        public long TeacherId { get; set; }

        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public long CreatedById { get; set; }
        public DateTime UpdatedOn { get; set; }
        public long UpdatedById { get; set; }

        public virtual User CreatedBy { get; set; }
        public virtual User UpdatedBy { get; set; }

        public virtual AcademicYear AcademicYear { get; set; }
        public virtual AcademicLevel AcademicLevel { get; set; }
        public virtual Subject Subject { get; set; }
        public virtual User Teacher { get; set; }
    }
}
