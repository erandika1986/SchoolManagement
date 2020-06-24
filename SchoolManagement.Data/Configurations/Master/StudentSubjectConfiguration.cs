using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagement.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Data.Configurations
{
    public class StudentSubjectConfiguration : IEntityTypeConfiguration<StudentSubject>
    {
        public void Configure(EntityTypeBuilder<StudentSubject> builder)
        {
            builder.ToTable("StudentSubject", Schema.MASTER);

            builder.HasKey(x => x.Id);

            builder
                .HasOne<AcademicYear>(s => s.AcademicYear)
                .WithMany(r => r.StudentSubjects)
                .HasForeignKey(f => f.AcademicYearId).OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne<Student>(s => s.Student)
                .WithMany(r => r.StudentSubjects)
                .HasForeignKey(f => f.StudentId).OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne<AcademicLevel>(s => s.AcademicLevel)
                .WithMany(r => r.StudentSubjects)
                .HasForeignKey(f => f.AcademicLevelId).OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne<Subject>(s => s.Subject)
                .WithMany(r => r.StudentSubjects)
                .HasForeignKey(f => f.SubjectId).OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne<SubjectAcademicLevel>(s => s.SubjectAcademicLevel)
                .WithMany(r => r.StudentSubjects)
                .HasForeignKey(f => new { f.SubjectId, f.AcademicLevelId }).OnDelete(DeleteBehavior.Restrict);


            builder
                .HasOne<User>(s => s.CreatedBy)
                .WithMany(r => r.CreatedStudentSubjects)
                .HasForeignKey(s => s.CreatedById).OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne<User>(s => s.UpdatedBy)
                .WithMany(r => r.UpdatedStudentSubjects)
                .HasForeignKey(s => s.UpdatedById).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
