using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Model
{
    public class MCQStudentAnswer
    {
        public long MCQAnswerId { get; set; }
        public long StudentId { get; set; }
        public long QuestionId { get; set; }
        public string AnswerText { get; set; }
        public int SequenceNo { get; set; }
        public bool? IsCorrectAnswer { get; set; }


        public DateTime ModifiedOn { get; set; }
        public DateTime CreatedOn { get; set; }

        public virtual MCQStudentQuestion MCQStudentQuestion { get; set; }
        public virtual MCQAnswer MCQAnswer { get; set; }




    }
}
