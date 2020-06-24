using SchoolManagement.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.ViewModel.Admin.Subject
{
    public class SubjectTeacherContainerViewModel
    {
        public SubjectTeacherContainerViewModel()
        {
            SubjectTeachers = new List<SubjectTeacherViewModel>();
        }
        public BasicAcademicYear AcademicYear { get; set; }
        public BasicAcademicLevelViewModel AcademicLevel { get; set; }
        public int MyProperty { get; set; }
        public List<SubjectTeacherViewModel> SubjectTeachers { get; set; }

    }

    public class SubjectTeacherViewModel
    {
        public SubjectTeacherViewModel()
        {
            Tecahers = new List<BasicUserViewModel>();
        }
        public BasicSubjectViewModel Subject { get; set; }
        public List<BasicUserViewModel> Tecahers { get; set; }
    }
}
