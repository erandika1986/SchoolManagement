using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagement.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Data
{
    public class StudentLessonConfiguration : IEntityTypeConfiguration<StudentLesson>
    {
        public void Configure(EntityTypeBuilder<StudentLesson> builder)
        {
            builder.ToTable("StudentLesson", Schema.LESSON);

            builder.HasKey(x => new { x.StudentId,x.LessonId});

            builder
                .HasOne<Lesson>(s => s.Lesson)
                .WithMany(r => r.StudentLessons)
                .HasForeignKey(s => s.LessonId).OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne<User>(s => s.Student)
                .WithMany(r => r.StudentLessons)
                .HasForeignKey(s => s.StudentId).OnDelete(DeleteBehavior.Restrict);


        }
    }
}
