using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagement.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Data.Configurations
{
    public class StudentClassConfiguration : IEntityTypeConfiguration<StudentClass>
    {
        public void Configure(EntityTypeBuilder<StudentClass> builder)
        {
            builder.ToTable("StudentClass", Schema.MASTER);

            builder.HasKey(x => x.Id);

            builder
                .HasOne<Student>(s => s.Student)
                .WithMany(r => r.StudentClasses)
                .HasForeignKey(f => f.StudentId).OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne<Class>(s => s.Class)
                .WithMany(r => r.StudentClasses)
                .HasForeignKey(f => new {f.ClassNameId,f.AcademicLevelId,f.AcademicYearId }).OnDelete(DeleteBehavior.Restrict);


            builder
                .HasOne<User>(s => s.CreatedBy)
                .WithMany(r => r.CreatedStudentClasses)
                .HasForeignKey(s => s.CreatedById).OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne<User>(s => s.UpdatedBy)
                .WithMany(r => r.UpdatedStudentClasses)
                .HasForeignKey(s => s.UpdatedById).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
