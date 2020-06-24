using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Model
{
    public class Student
    {
        public long Id { get; set; }
        public string AdmissionNo { get; set; }//Unique
        public string FullName { get; set; }
        public string EmegencyContactNo1 { get; set; }
        public string EmegencyContactNo2 { get; set; }
        public Gender Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public long? CreatedById { get; set; }
        public DateTime UpdatedOn { get; set; }
        public long? UpdatedById { get; set; }

        public virtual User CreatedBy { get; set; }
        public virtual User UpdatedBy { get; set; }

        public virtual ICollection<StudentSubject> StudentSubjects { get; set; }
        public virtual ICollection<StudentClass> StudentClasses { get; set; }
    }
}
