using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Model
{
    public class StudentSubjectScore
    {
        public long AssessmentTypeId { get; set; }
        public long StudentSubjectId { get; set; }


        public float GainedScore { get; set; }
        public float ScorePercent { get; set; }
        public float AllocatedScore { get; set; }
        public long GradeId { get; set; }

        public int LevelRank { get; set; }
        public int ScoreDifference { get; set; }

        public virtual StudentSubject StudentSubject { get; set; }
        public virtual AssessmentType AssessmentType { get; set; }
        public virtual Grade Grade { get; set; }
    }
}
