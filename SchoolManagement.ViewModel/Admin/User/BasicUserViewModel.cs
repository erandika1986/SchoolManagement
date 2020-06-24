using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.ViewModel
{
    public class BasicUserViewModel
    {
        public long Id { get; set; }
        public string FullName { get; set; }

        public bool IsChecked { get; set; }

        public bool IsPrimary { get; set; }
    }
}
