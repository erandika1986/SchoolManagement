using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagement.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Data.Configurations
{
    public class SubjectConfiguration : IEntityTypeConfiguration<Subject>
    {
        public void Configure(EntityTypeBuilder<Subject> builder)
        {
            builder.ToTable("Subject", Schema.MASTER);

            builder.HasKey(x => x.Id);

            builder.HasAlternateKey(x => x.Name);
            builder.HasAlternateKey(x => x.SubjectCode);

            builder.Property(e => e.SubjectStream)
                .HasDefaultValue(ALSubjectStream.None);

            builder
                .HasOne<User>(s => s.CreatedBy)
                .WithMany(r => r.CreatedSubjects)
                .HasForeignKey(s => s.CreatedById).OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne<User>(s => s.UpdatedBy)
                .WithMany(r => r.UpdatedSubjects)
                .HasForeignKey(s => s.UpdatedById).OnDelete(DeleteBehavior.Restrict);

            builder
            .HasOne<Subject>(s => s.ParentSubject)
            .WithMany(r => r.ChildBasketSubjects)
            .HasForeignKey(s => s.ParentBasketSubjectId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
