using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.ViewModel.Common
{
    public class BasicAcademicLevelViewModel
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public bool IsChecked { get; set; }

        public int NoOfPeriodPerWeek { get; set; }
    }
}
