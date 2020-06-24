using SchoolManagement.Model;
using SchoolManagement.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.ViewModel
{
    public class AssessmentTypeViewModel: ListItemBaseViewModel
    {
        public AssessmentTypeViewModel()
        {
            AcademicLevels = new List<BasicAcademicLevelViewModel>();
        }
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Month StartMonth { get; set; }
        public Month EndMonth { get; set; }
        public bool IsActive { get; set; }

        public string Levels { get; set; }
        public List<BasicAcademicLevelViewModel> AcademicLevels { get; set; }
    }
}
