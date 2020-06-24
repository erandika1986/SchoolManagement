using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Model
{
    public class EssayStudentAnswer
    {
        public long Id { get; set; }
        public long QuestonId { get; set; }
        public long StudentId { get; set; }
        public string AnswerText { get; set; }
        public string TeacherComments { get; set; }
        public decimal? Marks { get; set; }

        public DateTime ModifiedOn { get; set; }
        public DateTime CreatedOn { get; set; }

        public virtual Question Question { get; set; }
        public virtual User Student { get; set; }
    }
}
