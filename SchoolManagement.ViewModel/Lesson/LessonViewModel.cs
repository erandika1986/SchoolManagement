using SchoolManagement.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.ViewModel.Lesson
{
    public class LessonViewModel
    {

        public LessonViewModel()
        {
            TeacherLessonLevelEssayQuestions = new List<QuestionViewModel>();
            TeacherLessonLevelMCQQuestions = new List<QuestionViewModel>();
            StudentLessonLevelEssayQuestions = new List<EssayStudentQuestionViewModel>();
            StudentLessonLevelMCQQuestions = new List<MCQStudentQuestionViewModel>();

            TeacherTopics = new List<TopicViewModel>();

        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string LearningOutcome { get; set; }
        public DateTime? PlannedDate { get; set; }
        public DateTime? CompletedDate { get; set; }
        public LessonStatus Status { get; set; }
        public int Version { get; set; }
        public DropDownViewModal SelectedOwner { get; set; }
        public DropDownViewModal SelectedAcademicYear { get; set; }
        public DropDownViewModal SelectedAcademicLevel { get; set; }
        public DropDownViewModal SelectedClassNameId { get; set; }
        public DropDownViewModal SelectedSubject { get; set; }
        public List<TopicViewModel> TeacherTopics { get; set; }


        //Teachers Answers
        public List<QuestionViewModel> TeacherLessonLevelEssayQuestions { get; set; }
        public List<QuestionViewModel> TeacherLessonLevelMCQQuestions { get; set; }

        //Students Answer
        public List<EssayStudentQuestionViewModel> StudentLessonLevelEssayQuestions { get; set; }
        public List<MCQStudentQuestionViewModel> StudentLessonLevelMCQQuestions { get; set; }
    }
}
