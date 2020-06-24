using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagement.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Data.Configurations
{
    public class MCQStudentQuestionConfiguration : IEntityTypeConfiguration<MCQStudentQuestion>
    {
        public void Configure(EntityTypeBuilder<MCQStudentQuestion> builder)
        {
            builder.ToTable("MCQStudentQuestion", Schema.LESSON);

            builder.HasKey(x => new { x.StudentId, x.QuestionId });

            builder
                .HasOne<Question>(s => s.Question)
                .WithMany(r => r.MCQStudentQuestions)
                .HasForeignKey(s => s.QuestionId).OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne<User>(s => s.Student)
                .WithMany(r => r.MCQStudentQuestions)
                .HasForeignKey(s => s.StudentId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
