using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.ViewModel.Lesson
{
    public class TopicViewModel
    {

        public TopicViewModel()
        {
            TeacherTopicLevelEssayQuestions = new List<QuestionViewModel>();
            TeacherTopicLevelMCQQuestions = new List<QuestionViewModel>();
            StudentTopicLevelEssayQuestions = new List<EssayStudentQuestionViewModel>();
            StudentTopicLevelMCQQuestions = new List<MCQStudentQuestionViewModel>();

            TeacherTopicContents = new List<TopicContentViewModel>();
        }

        public long Id { get; set; }
        public long LessonId { get; set; }
        public int SequenceNo { get; set; }
        public string Name { get; set; }
        public string LearningExperience { get; set; }
        public List<TopicContentViewModel> TeacherTopicContents { get; set; }

        //Teachers Answers
        public List<QuestionViewModel> TeacherTopicLevelEssayQuestions { get; set; }
        public List<QuestionViewModel> TeacherTopicLevelMCQQuestions { get; set; }

        //Students Answer
        public List<EssayStudentQuestionViewModel> StudentTopicLevelEssayQuestions { get; set; }
        public List<MCQStudentQuestionViewModel> StudentTopicLevelMCQQuestions { get; set; }

    }
}
