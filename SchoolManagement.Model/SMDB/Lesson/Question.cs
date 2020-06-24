using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Model
{
    public class Question
    {
        public long Id { get; set; }

        public long? LessonId { get; set; }
        public long? TopicId { get; set; }

        public int SequenceNo { get; set; }
        public string QuestionText { get; set; }
        public decimal Marks { get; set; }
        public QuestionLevel QuestionLevel { get; set; }
        public QuestionType QuestionType { get; set; }

        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }

        public virtual Lesson Lesson { get; set; }
        public virtual Topic Topic { get; set; }
        
        public virtual ICollection<MCQAnswer> MCQAnswers { get; set; }
        public virtual ICollection<EssayAnswer> EssayAnswers { get; set; }
        public virtual ICollection<EssayStudentAnswer> EssayStudentAnswers { get; set; }
        public virtual ICollection<MCQStudentQuestion> MCQStudentQuestions { get; set; }
    }
}
