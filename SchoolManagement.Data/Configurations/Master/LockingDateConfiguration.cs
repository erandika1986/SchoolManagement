using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagement.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Data.Configurations
{
    public class LockingDateConfiguration : IEntityTypeConfiguration<LockingDate>
    {
        public void Configure(EntityTypeBuilder<LockingDate> builder)
        {
            builder.ToTable("LockingDate", Schema.MASTER);

            builder.HasKey(x => new { x.AcademicYearId,x.AcademicLevelId,x.SubjectId,x.AssessmentTypeId});


            builder
                .HasOne<AcademicYear>(s => s.AcademicYear)
                .WithMany(r => r.LockingDates)
                .HasForeignKey(s => s.AcademicYearId).OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne<AcademicLevel>(s => s.AcademicLevel)
                .WithMany(r => r.LockingDates)
                .HasForeignKey(s => s.AcademicLevelId).OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne<Subject>(s => s.Subject)
                .WithMany(r => r.LockingDates)
                .HasForeignKey(s => s.SubjectId).OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne<AssessmentType>(s => s.AssessmentType)
                .WithMany(r => r.LockingDates)
                .HasForeignKey(s => s.AssessmentTypeId).OnDelete(DeleteBehavior.Restrict);



            builder
                .HasOne<User>(s => s.CreatedBy)
                .WithMany(r => r.CreatedLockingDates)
                .HasForeignKey(s => s.CreatedById).OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne<User>(s => s.UpdatedBy)
                .WithMany(r => r.UpdatedLockingDates)
                .HasForeignKey(s => s.UpdatedById).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
