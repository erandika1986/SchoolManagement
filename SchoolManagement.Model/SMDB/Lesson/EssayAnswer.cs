using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Model
{
    public class EssayAnswer
    {
        public long Id { get; set; }
        public long QuestonId { get; set; }
        public string AnswerText { get; set; }

        public DateTime ModifiedOn { get; set; }
        public DateTime CreatedOn { get; set; }

        public virtual Question Question { get; set; }
    }
}
