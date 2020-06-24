using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagement.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Data.Configurations
{
    public class SubjectTeacherConfiguration : IEntityTypeConfiguration<SubjectTeacher>
    {
        public void Configure(EntityTypeBuilder<SubjectTeacher> builder)
        {
            builder.ToTable("SubjectTeacher", Schema.MASTER);

            builder.HasKey(x => x.Id);

            builder
                .HasOne<SubjectAcademicLevel>(s => s.SubjectAcademicLevel)
                .WithMany(r => r.SubjectTeachers)
                .HasForeignKey(s => new { s.SubjectId,s.AcademicLevelId }).OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne<AcademicYear>(s => s.AcademicYear)
                .WithMany(r => r.SubjectTeachers)
                .HasForeignKey(s => s.AcademicYearId).OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne<User>(s => s.Teacher)
                .WithMany(r => r.SubjectTeachers)
                .HasForeignKey(s => s.TeacherId).OnDelete(DeleteBehavior.Restrict);


            builder
                .HasOne<User>(s => s.CreatedBy)
                .WithMany(r => r.CreatedSubjectTeachers)
                .HasForeignKey(s => s.CreatedById).OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne<User>(s => s.UpdatedBy)
                .WithMany(r => r.UpdatedSubjectTeachers)
                .HasForeignKey(s => s.UpdatedById).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
