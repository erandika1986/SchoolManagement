using SchoolManagement.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.ViewModel.Admin.Class
{
    public class ClassSubjectTeacherConatinerViewModel
    {
        public ClassSubjectTeacherConatinerViewModel()
        {
            ClassSubjectTeachers = new List<ClassSubjectTeacherViewModel>();
            SelectedClassTeachers = new List<BasicUserViewModel>();
            Teachers = new List<BasicUserViewModel>();
        }
        public long SelectedClassNameId { get; set; }
        public long SelectedAcademicYearId { get; set; }
        public long SelectedAcademicLevelId { get; set; }

        public List<BasicUserViewModel> SelectedClassTeachers { get; set; }
        public List<BasicUserViewModel> Teachers { get; set; }

        public List<ClassSubjectTeacherViewModel> ClassSubjectTeachers { get; set; }
    }

    public class ClassSubjectTeacherViewModel
    {
        public ClassSubjectTeacherViewModel()
        {
            SubjectTeachers = new List<BasicSubjectTeacherViewModel>();

        }
        public BasicSubjectViewModel Subject { get; set; }

        public long SelectedSubjectTeacher { get; set; }
        public List<BasicSubjectTeacherViewModel> SubjectTeachers { get; set; }
    }

    public class BasicSubjectTeacherViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }
}
