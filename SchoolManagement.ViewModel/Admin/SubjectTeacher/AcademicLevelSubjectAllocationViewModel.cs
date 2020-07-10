using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.ViewModel.Admin.SubjectTeacher
{
    public class AcademicLevelSubjectsAllocationViewModel
    {
        public long AcademicYearId { get; set; }

        public long AcademicLevelId { get; set; }
        public string AcademicLevelName { get; set; }

        public long SubjectId { get; set; }
        public string SubjectName { get; set; }

        public string TechersName { get; set; }
    }


    public class SubjectAllocationDetailViewModel
    {

        public SubjectAllocationDetailViewModel()
        {
            AssignedTeachers = new List<DropDownViewModal>();
        }
        public long AcademicYearId { get; set; }
        public long AcademicLevelId { get; set; }
        public long SubjectId { get; set; }

        public List<DropDownViewModal> AssignedTeachers { get; set; }
    }
}
