using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.ViewModel.Lesson
{
    public class LessonFilterViewModel
    {
        public DropDownViewModal SelectedStatus { get; set; }
        public DropDownViewModal SelectedAcademicYear { get; set; }
        public DropDownViewModal SelectedAcademicLevel { get; set; }
        public DropDownViewModal SelectedSubject { get; set; }
        public DropDownViewModal SelectedClass { get; set; }
        public bool IsActive { get; set; }

        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
    }
}
