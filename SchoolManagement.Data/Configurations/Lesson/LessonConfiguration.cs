using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagement.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Data.Configurations
{
    public class LessonConfiguration : IEntityTypeConfiguration<Lesson>
    {
        public void Configure(EntityTypeBuilder<Lesson> builder)
        {
            builder.ToTable("Lesson", Schema.LESSON);

            builder.HasKey(x => x.Id);

            builder
                .HasOne<User>(s => s.CreatedBy)
                .WithMany(r => r.CreatedLessons)
                .HasForeignKey(s => s.CreatedById).OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne<User>(s => s.UpdatedBy)
                .WithMany(r => r.UpdatedLessons)
                .HasForeignKey(s => s.UpdatedById).OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne<User>(s => s.Owner)
                .WithMany(r => r.OwnerLessons)
                .HasForeignKey(s => s.OwnerId).OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne<SubjectAcademicLevel>(s => s.SubjectAcademicLevel)
                .WithMany(r => r.Lessons)
                .HasForeignKey(s => new { s.SubjectId,s.AcademicLevelId}).OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne<Class>(s => s.Class)
                .WithMany(r => r.Lessons)
                .HasForeignKey(s => new { s.ClassNameId, s.AcademicLevelId, s.AcademicYearId }).OnDelete(DeleteBehavior.Restrict).IsRequired(false);
        }


    }
}
