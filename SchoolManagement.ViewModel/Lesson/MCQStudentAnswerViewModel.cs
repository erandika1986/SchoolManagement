using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.ViewModel.Lesson
{
    public class MCQStudentAnswerViewModel
    {
        public long MCQAnswerId { get; set; }
        public long StudentId { get; set; }
        public long QuestionId { get; set; }
        public string AnswerText { get; set; }
        public int SequenceNo { get; set; }
        public bool? IsCorrectAnswer { get; set; }
    }
}
