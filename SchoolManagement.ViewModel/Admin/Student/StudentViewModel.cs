using SchoolManagement.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.ViewModel.Admin.Student
{
    public class StudentViewModel : ListItemBaseViewModel
    {
        public long Id { get; set; }
        public string AdmissionNo { get; set; }//Unique
        public string FullName { get; set; }
        public string EmegencyContactNo1 { get; set; }
        public string EmegencyContactNo2 { get; set; }
        public Gender Gender { get; set; }
        public string GenderInString { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public bool IsActive { get; set; }

        public string SelectedAcademicYearName { get; set; }
        public long SelectedAcademicYearId { get; set; }

        public string SelectedAcademicLevelName { get; set; }
        public long SelectedAcademicLevelId { get; set; }

        public string SelectedClassName { get; set; }
        public long SelectedClassNameId { get; set; }
    }
}
