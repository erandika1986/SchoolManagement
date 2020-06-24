using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Model
{
    public class Lesson
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public long OwnerId { get; set; }
        public long AcademicLevelId { get; set; }
        public long? ClassNameId { get; set; }
        public long? AcademicYearId { get; set; }
        public long SubjectId { get; set; }
        public string LearningOutcome { get; set; }
        public DateTime? PlannedDate { get; set; }
        public DateTime? CompletedDate { get; set; }
        public LessonStatus Status { get; set; }
        public int VersionNo { get; set; }


        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public long? CreatedById { get; set; }
        public DateTime UpdatedOn { get; set; }
        public long? UpdatedById { get; set; }

        public virtual User CreatedBy { get; set; }
        public virtual User UpdatedBy { get; set; }

        public virtual User Owner { get; set; }
        public virtual SubjectAcademicLevel  SubjectAcademicLevel { get; set; }
        public virtual Class Class { get; set; }


        public virtual ICollection<Topic> Topics { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
        public virtual ICollection<LessonChat> LessonChats { get; set; }
        public virtual ICollection<StudentLesson> StudentLessons { get; set; }

    }
}
