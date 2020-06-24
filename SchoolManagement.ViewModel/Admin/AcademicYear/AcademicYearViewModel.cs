using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.ViewModel
{
    public class AcademicYearViewModel: ListItemBaseViewModel
    {
        public AcademicYearViewModel()
        {
            AcademicLevelViewModels = new List<AcademicLevelViewModel>();
        }
        public long Id { get; set; }
        public long AcademicYear { get; set; }
        public int NoOfClassess { get; set; }
        public int Total { get; set; }
        public bool IsRowHide { get; set; }

        public List<AcademicLevelViewModel> AcademicLevelViewModels { get; set; }
    }
}
