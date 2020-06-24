using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagement.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Master
{
    public class SchoolConfiguration : IEntityTypeConfiguration<School>
    {
        public void Configure(EntityTypeBuilder<School> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(b => b.TenantId).HasDefaultValue(Guid.NewGuid());
            builder.Property(b => b.APIKey).HasDefaultValue(Guid.NewGuid());
            builder.Property(b => b.SecretKey).HasDefaultValue(Guid.NewGuid());
        }
    }
}
