using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagement.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Data.Configurations
{
    public class ClassTeacherConfiguration : IEntityTypeConfiguration<ClassTeacher>
    {
        public void Configure(EntityTypeBuilder<ClassTeacher> builder)
        {
            builder.ToTable("ClassTeacher", Schema.MASTER);

            builder.HasKey(x => new { x.ClassNameId, x.AcademicLevelId, x.AcademicYearId, x.TeacherId });

            builder
                .HasOne<Class>(s => s.Class)
                .WithMany(r => r.ClassTeachers)
                .HasForeignKey(s => new { s.ClassNameId, s.AcademicLevelId, s.AcademicYearId }).OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne<User>(s => s.Teacher)
                .WithMany(r => r.ClassTeachers)
                .HasForeignKey(s => s.TeacherId).OnDelete(DeleteBehavior.Restrict);



            builder
                .HasOne<User>(s => s.CreatedBy)
                .WithMany(r => r.CreatedClassTeachers)
                .HasForeignKey(s => s.CreatedById).OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne<User>(s => s.UpdatedBy)
                .WithMany(r => r.UpdatedClassTeachers)
                .HasForeignKey(s => s.UpdatedById).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
