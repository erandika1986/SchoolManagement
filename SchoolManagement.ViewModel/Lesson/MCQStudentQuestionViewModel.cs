using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.ViewModel.Lesson
{
    public class MCQStudentQuestionViewModel
    {
        public MCQStudentQuestionViewModel()
        {
            Answers = new List<MCQStudentAnswerViewModel>();
        }

        public long QuestionId { get; set; }
        public long StudentId { get; set; }
        public decimal? Marks { get; set; }
        public bool? IsCorrect { get; set; }
        public string TeacherComments { get; set; }

        public List<MCQStudentAnswerViewModel> Answers { get; set; }
    }
}
