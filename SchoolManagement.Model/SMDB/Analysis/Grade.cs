using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Model
{
    public class Grade
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Standard { get; set; }
        public float MaxMarks { get; set; }
        public float MinMarks { get; set; }
        public string ColorCode { get; set; }
        public string Description { get; set; }

        public virtual ICollection<StudentSubjectScore> StudentSubjectScores { get; set; }
    }
}
