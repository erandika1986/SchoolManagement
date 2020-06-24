using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.ViewModel.Admin.ClassName
{
    public class ClassNameViewModel : ListItemBaseViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Total { get; set; }
        public bool IsActive { get; set; }
    }
}
