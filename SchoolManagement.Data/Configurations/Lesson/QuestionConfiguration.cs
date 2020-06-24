using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagement.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Data.Configurations
{
    public class QuestionConfiguration : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.ToTable("Question", Schema.LESSON);

            builder.HasKey(x => x.Id);

            builder
                .HasOne<Lesson>(s => s.Lesson)
                .WithMany(r => r.Questions)
                .HasForeignKey(s => s.LessonId).OnDelete(DeleteBehavior.Restrict).IsRequired(false);

            builder
                .HasOne<Topic>(s => s.Topic)
                .WithMany(r => r.Questions)
                .HasForeignKey(s => s.TopicId).OnDelete(DeleteBehavior.Restrict).IsRequired(false);
        }
    }
}
