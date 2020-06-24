using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Model
{
    public class ClassTeacher
    {
        public long ClassNameId { get; set; }
        public long AcademicLevelId { get; set; }
        public long AcademicYearId { get; set; }
        public long TeacherId { get; set; }
        public bool IsPrimary { get; set; }

        public virtual Class Class { get; set; }
        public virtual User Teacher { get; set; }

        public DateTime CreatedOn { get; set; }
        public long CreatedById { get; set; }
        public DateTime UpdatedOn { get; set; }
        public long UpdatedById { get; set; }

        public virtual User CreatedBy { get; set; }
        public virtual User UpdatedBy { get; set; }
    }
}
