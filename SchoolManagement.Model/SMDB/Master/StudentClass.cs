using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Model
{
    public class StudentClass
    {
        public long Id { get; set; }
        public long StudentId { get; set; }
        public long ClassNameId { get; set; }
        public long AcademicLevelId { get; set; }
        public long AcademicYearId { get; set; }

        public virtual Student Student { get; set; }
        public virtual Class Class { get; set; }

        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public long? CreatedById { get; set; }
        public DateTime UpdatedOn { get; set; }
        public long? UpdatedById { get; set; }

        public virtual User CreatedBy { get; set; }
        public virtual User UpdatedBy { get; set; }



    }
}
