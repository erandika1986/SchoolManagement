using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Model
{
    public class Topic
    {
        public long Id { get; set; }
        public long LessonId { get; set; }
        public int SequenceNo { get; set; }
        public string Name { get; set; }
        public string LearningExperience { get; set; }

        public bool IsActive { get; set; }
        public DateTime ModifiedOn { get; set; }
        public DateTime CreatedOn { get; set; }

        public virtual Lesson Lesson { get; set; }

        public virtual ICollection<TopicContent> TopicContents { get; set; }
        public virtual ICollection<Question>  Questions { get; set; }
        public virtual ICollection<LessonChat> LessonChats { get; set; }
        public virtual ICollection<StudentTopic> StudentTopics { get; set; }
    }
}
