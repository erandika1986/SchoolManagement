using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.ViewModel.TimeTable
{
    public class TimeTableViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public bool IsPublished { get; set; }
        public string CreatedOn { get; set; }
        public string CreatedBy { get; set; }
    }
}
