using SchoolManagement.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.ViewModel.Lesson
{
    public class EssayStudentQuestionViewModel
    {
        public long Id { get; set; }

        public long LessonId { get; set; }
        public long TopicId { get; set; }

        public int SequenceNo { get; set; }
        public string QuestionText { get; set; }
        public decimal Marks { get; set; }
        public QuestionLevel QuestionLevel { get; set; }
        public QuestionType QuestionType { get; set; }

        //For Students Essay Answers
        public EssayStudentAnswerViewModel StudentEssayAnswer { get; set; }
    }
}
