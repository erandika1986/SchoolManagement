using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagement.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Data.Configurations
{
    public class TimeTableConfiguration : IEntityTypeConfiguration<TimeTable>
    {
        public void Configure(EntityTypeBuilder<TimeTable> builder)
        {
            builder.ToTable("TimeTable", Schema.TIMETABLE);

            builder.HasKey(x => x.Id);

            builder
                .HasOne<AcademicYear>(s => s.AcademicYear)
                .WithMany(r => r.TimeTables)
                .HasForeignKey(f => f.AcademicYearId).OnDelete(DeleteBehavior.Restrict);



            builder
                .HasOne<User>(s => s.CreatedBy)
                .WithMany(r => r.CreatedTimeTables)
                .HasForeignKey(s => s.CreatedById).OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne<User>(s => s.UpdatedBy)
                .WithMany(r => r.UpdatedTimeTables)
                .HasForeignKey(s => s.UpdatedById).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
