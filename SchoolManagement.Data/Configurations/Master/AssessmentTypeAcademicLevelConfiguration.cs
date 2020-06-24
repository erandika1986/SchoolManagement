using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagement.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Data.Configurations
{
    public class AssessmentTypeAcademicLevelConfiguration : IEntityTypeConfiguration<AssessmentTypeAcademicLevel>
    {
        public void Configure(EntityTypeBuilder<AssessmentTypeAcademicLevel> builder)
        {
            builder.ToTable("AssessmentTypeAcademicLevel", Schema.MASTER);

            builder.HasKey(x => new { x.AssessmentTypeId, x.AcademicLevelId });

            builder
                .HasOne<AcademicLevel>(s => s.AcademicLevel)
                .WithMany(r => r.AssessmentTypeAcademicLevels)
                .HasForeignKey(s => s.AcademicLevelId).OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne<AssessmentType>(s => s.AssessmentType)
                .WithMany(r => r.AssessmentTypeAcademicLevels)
                .HasForeignKey(s => s.AssessmentTypeId).OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne<User>(s => s.CreatedBy)
                .WithMany(r => r.CreatedAssessmentTypeAcademicLevels)
                .HasForeignKey(s => s.CreatedById).OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne<User>(s => s.UpdatedBy)
                .WithMany(r => r.UpdatedAssessmentTypeAcademicLevels)
                .HasForeignKey(s => s.UpdatedById).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
