﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.ViewModel.Admin.ClassSubjectTeacher
{
    public class ClassSubjectTeacherMasterDataViewModel
    {
        public ClassSubjectTeacherMasterDataViewModel()
        {
            AcademicYears = new List<DropDownViewModal>();
            AcademicLevels = new List<DropDownViewModal>();
            ClassCategories = new List<DropDownViewModal>();
            LanguageStreams = new List<DropDownViewModal>();
        }

        public List<DropDownViewModal> AcademicYears { get; set; }
        public List<DropDownViewModal> AcademicLevels { get; set; }
        public List<DropDownViewModal> ClassCategories { get; set; }
        public List<DropDownViewModal> LanguageStreams { get; set; }
    }
}
