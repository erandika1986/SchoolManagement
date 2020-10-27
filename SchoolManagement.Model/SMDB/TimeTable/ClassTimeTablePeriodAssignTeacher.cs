using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Model
{
    public class ClassTimeTablePeriodAssignTeacher
    {
        public long Id { get; set; }
        public long ClassTimeTablePeriodId { get; set; }
        public long TeacherId { get; set; }
        public DateTime AllocatedDate { get; set; }
        public DateTime DeallocatedDate { get; set; }

        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public long CreatedById { get; set; }
        public DateTime UpdatedOn { get; set; }
        public long UpdatedById { get; set; }

        public virtual User CreatedBy { get; set; }
        public virtual User UpdatedBy { get; set; }

        public virtual ClassTimeTablePeriod ClassTimeTablePeriod { get; set; }
        public virtual User Teacher { get; set; }

    }
}
