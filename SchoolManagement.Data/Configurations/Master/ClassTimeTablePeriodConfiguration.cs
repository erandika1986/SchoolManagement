using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagement.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Data.Configurations
{
    public class ClassTimeTablePeriodConfiguration : IEntityTypeConfiguration<ClassTimeTablePeriod>
    {
        public void Configure(EntityTypeBuilder<ClassTimeTablePeriod> builder)
        {
            builder.ToTable("ClassTimeTablePeriod", "Master");

            builder.HasKey(x => x.Id);



            builder
                .HasOne<Class>(s => s.Class)
                .WithMany(r => r.ClassTimeTablePeriods)
                .HasForeignKey(f => new { f.ClassNameId, f.AcademicLevelId, f.AcademicYearId }).OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne<Day>(s => s.Day)
                .WithMany(r => r.ClassTimeTablePeriods)
                .HasForeignKey(f => f.DayId).OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne<Period>(s => s.Period)
                .WithMany(r => r.ClassTimeTablePeriods)
                .HasForeignKey(f => f.PeriodId).OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne<SubjectAcademicLevel>(s => s.Subject)
                .WithMany(r => r.ClassTimeTablePeriods)
            .HasForeignKey(f => new {f.SubjectId,f.AcademicLevelId }).OnDelete(DeleteBehavior.Restrict);



            builder
                .HasOne<User>(s => s.CreatedBy)
                .WithMany(r => r.CreatedClassTimeTablePeriods)
                .HasForeignKey(s => s.CreatedById).OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne<User>(s => s.UpdatedBy)
                .WithMany(r => r.UpdatedClassTimeTablePeriods)
                .HasForeignKey(s => s.UpdatedById).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
