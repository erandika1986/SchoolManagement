using SchoolManagement.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.ViewModel.Lesson
{
    public class LessonChatViewModel
    {
        public long Id { get; set; }
        public long LessonId { get; set; }
        public long? TopicId { get; set; }
        public long FromUserId { get; set; }
        public long ToUserId { get; set; }
        public string Message { get; set; }
        public MessageType MessageType { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
