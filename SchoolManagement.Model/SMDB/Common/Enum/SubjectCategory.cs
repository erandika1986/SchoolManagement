using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace SchoolManagement.Model
{
    public enum SubjectCategory
    {
        [Description("Junior School Subject")]
        JuniorSchoolSubject=1,
        [Description("Senior School Subject")]
        SeniorSchoolSubject =2
    }
}
