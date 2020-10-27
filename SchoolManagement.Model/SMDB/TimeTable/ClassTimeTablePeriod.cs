using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Model
{
    public class ClassTimeTablePeriod
    {
        public long Id { get; set; }
        public long TimeTableId { get; set; }
        public long ClassNameId { get; set; }
        public long AcademicLevelId { get; set; }
        public long AcademicYearId { get; set; }
        public long DayId { get; set; }


        public long PeriodId { get; set; }
        public long SubjectId { get; set; }

        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public long? CreatedById { get; set; }
        public DateTime UpdatedOn { get; set; }
        public long? UpdatedById { get; set; }

        public virtual Class Class { get; set; }
        public virtual Day Day { get; set; }
        public virtual Period Period { get; set; }
        public virtual SubjectAcademicLevel Subject { get; set; }


        public virtual User CreatedBy { get; set; }
        public virtual User UpdatedBy { get; set; }
        public virtual TimeTable TimeTable { get; set; }

        public virtual ICollection<ClassTimeTablePeriodAssignTeacher> ClassTimeTablePeriodAssignTeachers { get; set; }


    }
}
