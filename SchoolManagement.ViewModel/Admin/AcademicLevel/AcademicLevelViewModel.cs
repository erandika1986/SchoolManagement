using SchoolManagement.ViewModel.Admin.Class;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.ViewModel
{
    public class AcademicLevelViewModel:ListItemBaseViewModel
    {
        public AcademicLevelViewModel()
        {
            Classes = new List<ClassViewModel>();
        }

        public long Id { get; set; }
        public string Description { get; set; }
        public long LevelHeadId { get; set; }
        public string LevelHeadName { get; set; }
        public List<ClassViewModel> Classes { get; set; }
        public bool IsActive { get; set; }
    }
}
