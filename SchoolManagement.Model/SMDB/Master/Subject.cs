using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Model
{
    public class Subject
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string SubjectCode { get; set; }
        public SubjectCategory SubjectCategory { get; set; }
        public bool IsParentBasketSubject { get; set; }
        public bool IsBuscketSubject { get; set; }
        public long? ParentBasketSubjectId { get; set; }
        public ALSubjectStream SubjectStream { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public long CreatedById { get; set; }
        public DateTime UpdatedOn { get; set; }
        public long UpdatedById { get; set; }

        public virtual User CreatedBy { get; set; }
        public virtual User UpdatedBy { get; set; }

        public virtual Subject ParentSubject { get; set; }


        public virtual ICollection<SubjectAcademicLevel> SubjectAcademicLevels { get; set; }
        public virtual ICollection<StudentSubject> StudentSubjects { get; set; }
        public virtual ICollection<HeadOfDepartment> HeadOfDepartments { get; set; }
        public virtual ICollection<LockingDate> LockingDates { get; set; }

        public virtual ICollection<Subject> ChildBasketSubjects { get; set; }


        //public virtual ICollection<BasketSubject> ParentBasketSubjects { get; set; }
        //public virtual ICollection<BasketSubject> BasketSubjects { get; set; }
    }
}
