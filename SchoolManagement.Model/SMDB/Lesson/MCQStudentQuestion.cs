using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Model
{
    public class MCQStudentQuestion
    {
        public long QuestionId { get; set; }
        public long StudentId { get; set; }
        public decimal? Marks { get; set; }
        public bool? IsCorrect { get; set; }
        public string TeacherComments { get; set; }

        public DateTime SubmittedOn { get; set; }
        public virtual Question Question { get; set; }
        public virtual User Student { get; set; }

        public virtual ICollection<MCQStudentAnswer> MCQStudentAnswers { get; set; }
    }
}
