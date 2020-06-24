using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagement.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Data.Configurations
{
    public class ClassSubjectTeacherConfiguration : IEntityTypeConfiguration<ClassSubjectTeacher>
    {
        public void Configure(EntityTypeBuilder<ClassSubjectTeacher> builder)
        {
            builder.ToTable("ClassSubjectTeacher", Schema.MASTER);


            builder.HasKey(x => x.Id);

            builder
                .HasOne<Class>(s => s.Class)
                .WithMany(r => r.ClassSubjectTeachers)
                .HasForeignKey(s => new { s.ClassNameId,s.AcademicLevelId,s.AcademicYearId }).OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne<SubjectAcademicLevel>(s => s.SubjectAcademicLevel)
                .WithMany(r => r.ClassSubjectTeachers)
                .HasForeignKey(s => new { s.SubjectId, s.AcademicLevelId }).OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne<SubjectTeacher>(s => s.SubjectTeacher)
                .WithMany(r => r.ClassSubjectTeachers)
                .HasForeignKey(s => s.SubjectTeacherId).OnDelete(DeleteBehavior.Restrict);


            builder
                .HasOne<User>(s => s.CreatedBy)
                .WithMany(r => r.CreatedClassSubjectTeachers)
                .HasForeignKey(s => s.CreatedById).OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne<User>(s => s.UpdatedBy)
                .WithMany(r => r.UpdatedClassSubjectTeachers)
                .HasForeignKey(s => s.UpdatedById).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
