using SchoolManagement.Model;
using SchoolManagement.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.ViewModel.Admin.Subject
{
    public class SubjectViewModel : ListItemBaseViewModel
    {
        public SubjectViewModel()
        {
            AcademicLevels = new List<BasicAcademicLevelViewModel>();
            SubjectTeachers = new List<BasicUserViewModel>();
            ParentSubjects = new List<BasicSubjectViewModel>();
            ParentSubjects.Add(new BasicSubjectViewModel() { Id = 0, Name = "None" });
            SubjectStreams = new List<DropDownViewModal>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string SubjectCode { get; set; }
        public bool IsBasketSubject { get; set; }
        public bool IsParentBasketSubject { get; set; }
        public SubjectCategory SubjectCategory { get; set; }
        public ALSubjectStream SubjectStream { get; set; }
        public bool IsActive { get; set; }

        //public List<int> BasketSubjects { get; set; }
        public long ParentSubjectId { get; set; }
        public List<BasicSubjectViewModel> ParentSubjects { get; set; }
        public List<BasicAcademicLevelViewModel> AcademicLevels { get; set; }
        public List<BasicUserViewModel> SubjectTeachers { get; set; }

        public List<DropDownViewModal> SubjectStreams { get; set; }
    }

    public class BasketSubjectViewModel
    {
        public BasketSubjectViewModel()
        {
            BasketSubjects = new List<BasicSubjectViewModel>();
        }

        public long ParentBasketSubjectId { get; set; }

        public List<BasicSubjectViewModel> BasketSubjects { get; set; }
    }
}
