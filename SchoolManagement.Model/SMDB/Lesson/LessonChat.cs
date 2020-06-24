using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Model
{
    public class LessonChat
    {
        public long Id { get; set; }
        public long LessonId { get; set; }
        public long? TopicId { get; set; }
        public long FromUserId { get; set; }
        public long ToUserId { get; set; }
        public string Message { get; set; }
        public MessageType MessageType { get; set; }
        public DateTime CreatedOn { get; set; }

        public virtual User FromUser { get; set; }
        public virtual User ToUser { get; set; }
        public virtual Lesson Lesson { get; set; }
        public virtual Topic Topic { get; set; }
    }
}
