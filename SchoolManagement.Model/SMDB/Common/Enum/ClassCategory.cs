using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace SchoolManagement.Model
{
    public enum ClassCategory
    {
        [Description("O/Level")]
        OLevel=1,
        [Description("A/Level-Maths")]
        ALevelMaths =2,
        [Description("A/Level-Bio")]
        ALevelBio =3,
        [Description("A/Level-Technology")]
        ALevelTechnology =4,
        [Description("A/Level-Commerce")]
        ALevelCommerce =5
    }

    public enum LanguageStream
    {
        [Description("Sinhala")]
        Sinhala =1,
        [Description("English")]
        English =2
    }
}
