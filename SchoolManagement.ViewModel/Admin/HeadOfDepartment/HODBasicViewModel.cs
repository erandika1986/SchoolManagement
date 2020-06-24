using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.ViewModel.Admin.HeadOfDepartment
{
    public class HODBasicViewModel : ListItemBaseViewModel
    {
        public long Id { get; set; }
        public int AcademicYear { get; set; }
        public string Subject { get; set; }
        public string HODs { get; set; }
    }
}
