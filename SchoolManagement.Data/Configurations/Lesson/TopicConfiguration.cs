using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagement.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Data.Configurations
{
    public class TopicConfiguration : IEntityTypeConfiguration<Topic>
    {
        public void Configure(EntityTypeBuilder<Topic> builder)
        {
            builder.ToTable("Topic", Schema.LESSON);

            builder.HasKey(x => x.Id);

            builder
            .HasOne<Lesson>(s => s.Lesson)
            .WithMany(r => r.Topics)
            .HasForeignKey(s => s.LessonId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
