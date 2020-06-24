using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagement.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Data.Configurations
{
    public class EssayStudentAnswerConfiguration : IEntityTypeConfiguration<EssayStudentAnswer>
    {
        public void Configure(EntityTypeBuilder<EssayStudentAnswer> builder)
        {
            builder.ToTable("EssayStudentAnswer", Schema.LESSON);

            builder.HasKey(x => x.Id);

            builder
                .HasOne<Question>(s => s.Question)
                .WithMany(r => r.EssayStudentAnswers)
                .HasForeignKey(s => s.QuestonId).OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne<User>(s => s.Student)
                .WithMany(r => r.EssayStudentAnswers)
                .HasForeignKey(s => s.StudentId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
