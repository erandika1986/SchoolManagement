using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagement.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Data.Configurations
{
    public class AssessmentTypeConfiguration : IEntityTypeConfiguration<AssessmentType>
    {
        public void Configure(EntityTypeBuilder<AssessmentType> builder)
        {
            builder.ToTable("AssessmentType", Schema.MASTER);

            builder.HasKey(x => x.Id);

            builder
                .HasOne<User>(s => s.CreatedBy)
                .WithMany(r => r.CreatedAssessmentTypes)
                .HasForeignKey(s => s.CreatedById).OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne<User>(s => s.UpdatedBy)
                .WithMany(r => r.UpdatedAssessmentTypes)
                .HasForeignKey(s => s.UpdatedById).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
