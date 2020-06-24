using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Model
{
    public class MCQAnswer
    {
        public long Id { get; set; }
        public long QuestonId { get; set; }
        public string AnswerText { get; set; }
        public int SequenceNo { get; set; }
        public bool IsCorrectAnswer { get; set; }

        public DateTime ModifiedOn { get; set; }
        public DateTime CreatedOn { get; set; }

        public virtual Question Question { get; set; }

        public virtual ICollection<MCQStudentAnswer> MCQStudentAnswers { get; set; }
    }
}
