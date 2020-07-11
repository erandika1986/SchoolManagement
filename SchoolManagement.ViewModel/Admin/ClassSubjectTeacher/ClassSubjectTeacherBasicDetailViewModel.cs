using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.ViewModel.Admin.ClassSubjectTeacher
{
    public class ClassSubjectTeacherBasicDetailViewModel
    {
        public long AcademicYearId { get; set; }
        public long AcademicLevelId { get; set; }
        public long ClassNameId { get; set; }

        public string AcademicLevelName { get; set; }
        public string Name { get; set; }
        public string UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
    }


    public class ClassSubjectTeacherViewModel
    {
        public ClassSubjectTeacherViewModel()
        {
            //ClassTeachers = new List<ClassTeacherViewModel>();
            ClassSubjectTeachers = new List<SubjectTeacherViewModel>();
        }

        public long AcademicYearId { get; set; }
        public long AcademicLevelId { get; set; }
        public long ClassNameId { get; set; }
        public long SelectedClassTeacherId { get; set; }
        public bool IsvalidClassTeacher { get; set; }
        public string ValidationMsg { get; set; }

        //public List<ClassTeacherViewModel> ClassTeachers { get; set; }
        public List<SubjectTeacherViewModel> ClassSubjectTeachers { get; set; }

    }

    public class ClassTeacherViewModel
    {
        public long ClassNameId { get; set; }
        public long AcademicLevelId { get; set; }
        public long AcademicYearId { get; set; }
        public long SelectedTeacherId { get; set; }
        public bool IsPrimaryTeacher { get; set; }
    }

    public class SubjectTeacherViewModel
    {
        public SubjectTeacherViewModel()
        {
            SubjectTeachers = new List<DropDownViewModal>();
        }
        public List<DropDownViewModal> SubjectTeachers { get; set; }
        public long SelectedSubjectId { get; set; }
        public long SelectedTeacherId { get; set; }
        public bool Isvalid { get; set; }
        public string ValidationMsg { get; set; }
    }
}
