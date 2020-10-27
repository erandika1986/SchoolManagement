using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagement.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Data.Configurations
{
    public class ClassConfiguration : IEntityTypeConfiguration<Class>
    {
        public void Configure(EntityTypeBuilder<Class> builder)
        {
            builder.ToTable("Class", Schema.MASTER);


            builder.HasKey(x => new { x.ClassNameId,x.AcademicLevelId,x.AcademicYearId});

            builder.Property(e => e.ClassCategory)
                .HasDefaultValue(ClassCategory.OLevel);

            builder.Property(e => e.LanguageStream)
                 .HasDefaultValue(LanguageStream.English);
                

            builder
                .HasOne<ClassName>(c => c.ClassName)
                .WithMany(r => r.Classes)
                .HasForeignKey(s => s.ClassNameId).OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne<AcademicLevel>(c => c.AcademicLevel)
                .WithMany(r => r.Classes)
                .HasForeignKey(s => s.AcademicLevelId).OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne<AcademicYear>(c => c.AcademicYear)
                .WithMany(r => r.Classes)
                .HasForeignKey(s => s.AcademicYearId).OnDelete(DeleteBehavior.Restrict);



            builder
                .HasOne<User>(s => s.CreatedBy)
                .WithMany(r => r.CreatedClasses)
                .HasForeignKey(s => s.CreatedById).OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne<User>(s => s.UpdatedBy)
                .WithMany(r => r.UpdatedClasses)
                .HasForeignKey(s => s.UpdatedById).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
