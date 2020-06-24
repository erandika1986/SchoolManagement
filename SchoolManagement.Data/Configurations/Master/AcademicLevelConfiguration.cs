using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagement.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Data.Configurations
{
    public class AcademicLevelConfiguration : IEntityTypeConfiguration<AcademicLevel>
    {
        public void Configure(EntityTypeBuilder<AcademicLevel> builder)
        {
            builder.ToTable("AcademicLevel", Schema.MASTER);

            builder.HasKey(x => x.Id);

            builder.HasAlternateKey(x => x.Description);

            builder
                .HasOne<User>(s => s.CreatedBy)
                .WithMany(r => r.CreatedAcademicLevels)
                .HasForeignKey(s => s.CreatedById).OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne<User>(s => s.UpdatedBy)
                .WithMany(r => r.UpdatedAcademicLevels)
                .HasForeignKey(s => s.UpdatedById).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
