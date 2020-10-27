using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagement.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Data.Configurations
{
    public class ClassTimeTablePeriodAssignTeacherConfiguration : IEntityTypeConfiguration<ClassTimeTablePeriodAssignTeacher>
    {
        public void Configure(EntityTypeBuilder<ClassTimeTablePeriodAssignTeacher> builder)
        {
            builder.ToTable("ClassTimeTablePeriodAssignTeacher", Schema.TIMETABLE);

            builder.HasKey(x => x.Id);

            builder
                .HasOne<ClassTimeTablePeriod>(s => s.ClassTimeTablePeriod)
                .WithMany(r => r.ClassTimeTablePeriodAssignTeachers)
                .HasForeignKey(s => s.ClassTimeTablePeriodId).OnDelete(DeleteBehavior.Restrict);


            builder
                .HasOne<User>(s => s.Teacher)
                .WithMany(r => r.ClassTimeTablePeriodAssignTeachers)
                .HasForeignKey(s => s.TeacherId).OnDelete(DeleteBehavior.Restrict);


            builder
                .HasOne<User>(s => s.CreatedBy)
                .WithMany(r => r.CreatedClassTimeTablePeriodAssignTeachers)
                .HasForeignKey(s => s.CreatedById).OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne<User>(s => s.UpdatedBy)
                .WithMany(r => r.UpdatedClassTimeTablePeriodAssignTeachers)
                .HasForeignKey(s => s.UpdatedById).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
