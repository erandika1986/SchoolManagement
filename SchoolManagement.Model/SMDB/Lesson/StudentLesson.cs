using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Model
{
    public class StudentLesson
    {
        public long StudentId { get; set; }
        public long LessonId { get; set; }
        public DULessonStatus Status { get; set; }
        public DateTime? JoinDate { get; set; }
        public DateTime? CompletedDate { get; set; }
        public decimal? LessonMark { get; set; }

        public virtual User Student { get; set; }
        public virtual Lesson Lesson { get; set; }


    }
}
