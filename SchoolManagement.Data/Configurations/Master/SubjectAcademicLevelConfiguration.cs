using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagement.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Data.Configurations
{
    public class SubjectAcademicLevelConfiguration : IEntityTypeConfiguration<SubjectAcademicLevel>
    {
        public void Configure(EntityTypeBuilder<SubjectAcademicLevel> builder)
        {
            builder.ToTable("SubjectAcademicLevel", Schema.MASTER);

            builder.HasKey(x => new { x.SubjectId,x.AcademicLevelId });


            builder
                .HasOne<Subject>(s => s.Subject)
                .WithMany(r => r.SubjectAcademicLevels)
                .HasForeignKey(s => s.SubjectId).OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne<AcademicLevel>(s => s.AcademicLevel)
                .WithMany(r => r.SubjectAcademicLevels)
                .HasForeignKey(s => s.AcademicLevelId).OnDelete(DeleteBehavior.Restrict);



            builder
                .HasOne<User>(s => s.CreatedBy)
                .WithMany(r => r.CreatedSubjectAcademicLevels)
                .HasForeignKey(s => s.CreatedById).OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne<User>(s => s.UpdatedBy)
                .WithMany(r => r.UpdatedSubjectAcademicLevels)
                .HasForeignKey(s => s.UpdatedById).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
