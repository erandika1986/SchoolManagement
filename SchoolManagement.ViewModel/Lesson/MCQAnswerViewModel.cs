using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.ViewModel.Lesson
{
    public class MCQAnswerViewModel
    {
        public long Id { get; set; }
        public long QuestonId { get; set; }
        public string AnswerText { get; set; }
        public int SequenceNo { get; set; }
        public bool IsCorrectAnswer { get; set; }
    }
}
