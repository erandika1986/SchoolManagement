using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagement.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Data.Configurations
{
    public class MCQStudentAnswerConfiguration : IEntityTypeConfiguration<MCQStudentAnswer>
    {
        public void Configure(EntityTypeBuilder<MCQStudentAnswer> builder)
        {
            builder.ToTable("MCQStudentAnswer", Schema.LESSON);

            builder.HasKey(x => new { x.MCQAnswerId,x.StudentId,x.QuestionId });

            builder
                .HasOne<MCQStudentQuestion>(s => s.MCQStudentQuestion)
                .WithMany(r => r.MCQStudentAnswers)
                .HasForeignKey(s => new { s.StudentId, s.QuestionId }).OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne<MCQAnswer>(s => s.MCQAnswer)
                .WithMany(r => r.MCQStudentAnswers)
                .HasForeignKey(s => s.MCQAnswerId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
