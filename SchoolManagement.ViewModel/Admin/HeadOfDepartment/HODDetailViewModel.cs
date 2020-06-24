using SchoolManagement.ViewModel.Admin.AcademicLevel;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.ViewModel.Admin.HeadOfDepartment
{
    public class HODDetailViewModel
    {
        public HODDetailViewModel()
        {
            HODs = new List<HODTeacher>();
        }
        public long Id { get; set; }
        public long SelectedAcademicYearId { get; set; }
        public long SelectedSubjectId { get; set; }
        public List<HODTeacher> HODs { get; set; }
        public string CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
    }

    public class HODTeacher
    {
        public HODTeacher()
        {
            AssignedLevels = new List<AcademicLevelSelectionViewModel>();
        }
        public long TeacherId { get; set; }
        public List<AcademicLevelSelectionViewModel> AssignedLevels { get; set; }
    }
}
