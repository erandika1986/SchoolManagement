using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagement.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Data.Configurations
{
    public class ClassNameConfiguration : IEntityTypeConfiguration<ClassName>
    {
        public void Configure(EntityTypeBuilder<ClassName> builder)
        {
            builder.ToTable("ClassName", Schema.MASTER);


            builder.HasKey(x => x.Id);

            builder.HasAlternateKey(x => x.Name);

            builder
                .HasOne<User>(s => s.CreatedBy)
                .WithMany(r => r.CreatedClassNames)
                .HasForeignKey(s => s.CreatedById).OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne<User>(s => s.UpdatedBy)
                .WithMany(r => r.UpdatedClassNames)
                .HasForeignKey(s => s.UpdatedById).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
