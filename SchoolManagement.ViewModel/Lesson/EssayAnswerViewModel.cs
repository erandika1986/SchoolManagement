using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.ViewModel.Lesson
{
    public class EssayAnswerViewModel
    {
        public long Id { get; set; }
        public long QuestonId { get; set; }
        public string AnswerText { get; set; }
    }
}
