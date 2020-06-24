using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagement.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Data
{
    public class StudentTopicConfiguraton : IEntityTypeConfiguration<StudentTopic>
    {
        public void Configure(EntityTypeBuilder<StudentTopic> builder)
        {
            builder.ToTable("StudentTopic", Schema.LESSON);

            builder.HasKey(x => new { x.StudentId, x.TopicId });

            builder
                .HasOne<Topic>(s => s.Topic)
                .WithMany(r => r.StudentTopics)
                .HasForeignKey(s => s.TopicId).OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne<User>(s => s.Student)
                .WithMany(r => r.StudentTopics)
                .HasForeignKey(s => s.StudentId).OnDelete(DeleteBehavior.Restrict);


        }
    }
}
