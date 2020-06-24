using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Model
{
    public class StudentTopic
    {
        public long StudentId { get; set; }
        public long TopicId { get; set; }
        public DULessonStatus Status { get; set; }
        public DateTime? JoinDate { get; set; }
        public DateTime? CompletedDate { get; set; }
        public decimal? TaskMarks { get; set; }

        public virtual Topic Topic { get; set; }
        public virtual User Student { get; set; }
    }
}
