using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.ViewModel.Lesson
{
    public class EssayStudentAnswerViewModel
    {
        public long Id { get; set; }
        public long QuestonId { get; set; }
        public long StudentId { get; set; }
        public string AnswerText { get; set; }
        public decimal? Marks { get; set; }
    }
}
