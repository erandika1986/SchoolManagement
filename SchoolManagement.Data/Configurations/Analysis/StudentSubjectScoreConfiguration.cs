using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagement.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Data.Configurations
{
    public class StudentSubjectScoreConfiguration : IEntityTypeConfiguration<StudentSubjectScore>
    {
        public void Configure(EntityTypeBuilder<StudentSubjectScore> builder)
        {
            builder.ToTable("StudentSubjectScore", Schema.ANALYSIS);

            builder.HasKey(x => new { x.AssessmentTypeId,x.StudentSubjectId});

            builder
                .HasOne<AssessmentType>(s => s.AssessmentType)
                .WithMany(r => r.StudentSubjectScores)
                .HasForeignKey(f => f.AssessmentTypeId).OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne<StudentSubject>(s => s.StudentSubject)
                .WithMany(r => r.StudentSubjectScores)
                .HasForeignKey(f => f.StudentSubjectId).OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne<Grade>(s => s.Grade)
                .WithMany(r => r.StudentSubjectScores)
                .HasForeignKey(f => f.GradeId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
