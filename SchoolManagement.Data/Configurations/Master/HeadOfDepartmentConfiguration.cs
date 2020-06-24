using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagement.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Data.Configurations
{
    public class HeadOfDepartmentConfiguration : IEntityTypeConfiguration<HeadOfDepartment>
    {
        public void Configure(EntityTypeBuilder<HeadOfDepartment> builder)
        {
            builder.ToTable("HeadOfDepartment", Schema.MASTER);

            builder.HasKey(x => x.Id);


            builder
                .HasOne<AcademicYear>(s => s.AcademicYear)
                .WithMany(r => r.HeadOfDepartments)
                .HasForeignKey(s => s.AcademicYearId).OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne<AcademicLevel>(s => s.AcademicLevel)
                .WithMany(r => r.HeadOfDepartments)
                .HasForeignKey(s => s.AcademicLevelId).OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne<Subject>(s => s.Subject)
                .WithMany(r => r.HeadOfDepartments)
                .HasForeignKey(s => s.SubjectId).OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne<User>(s => s.Teacher)
                .WithMany(r => r.HeadOfDepartments)
                .HasForeignKey(s => s.TeacherId).OnDelete(DeleteBehavior.Restrict);



            builder
                .HasOne<User>(s => s.CreatedBy)
                .WithMany(r => r.CreatedHeadOfDepartments)
                .HasForeignKey(s => s.CreatedById).OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne<User>(s => s.UpdatedBy)
                .WithMany(r => r.UpdatedHeadOfDepartments)
                .HasForeignKey(s => s.UpdatedById).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
