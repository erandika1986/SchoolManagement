using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagement.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Data.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Role", Schema.ACCOUNT);

            builder.HasKey(x => x.Id);

            builder
                .HasOne<User>(s => s.CreatedBy)
                .WithMany(r => r.CreatedRoles)
                .HasForeignKey(s => s.CreatedById).OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne<User>(s => s.UpdatedBy)
                .WithMany(r => r.UpdatedRoles)
                .HasForeignKey(s => s.UpdatedById).OnDelete(DeleteBehavior.Restrict);


            var superAdmin = new Role()
            {
                Id=1,
                CreatedOn=DateTime.UtcNow,
                IsActive=true,
                UpdatedOn=DateTime.UtcNow,
                UpdatedById=1,
                CreatedById=1,
                Name = "SuperAdmin",
                Description = "SuperAdmin"
            };

            var admin = new Role()
            {
                Id = 2,
                CreatedOn = DateTime.UtcNow,
                IsActive = true,
                UpdatedOn = DateTime.UtcNow,
                UpdatedById = 1,
                CreatedById = 1,
                Name = "Admin",
                Description = "Admin"
            };

            var principle = new Role()
            {
                Id = 3,
                CreatedOn = DateTime.UtcNow,
                IsActive = true,
                UpdatedOn = DateTime.UtcNow,
                UpdatedById = 1,
                CreatedById = 1,
                Name = "Principle",
                Description = "Principle"
            };

            var levelHead = new Role()
            {
                Id = 4,
                CreatedOn = DateTime.UtcNow,
                IsActive = true,
                UpdatedOn = DateTime.UtcNow,
                UpdatedById = 1,
                CreatedById = 1,
                Name = "LevelHead",
                Description = "LevelHead"
            };

            var hod = new Role()
            {
                Id = 5,
                CreatedOn = DateTime.UtcNow,
                IsActive = true,
                UpdatedOn = DateTime.UtcNow,
                UpdatedById = 1,
                CreatedById = 1,
                Name = "HOD",
                Description = "HOD"
            };

            var teacher = new Role()
            {
                Id = 6,
                CreatedOn = DateTime.UtcNow,
                IsActive = true,
                UpdatedOn = DateTime.UtcNow,
                UpdatedById = 1,
                CreatedById = 1,
                Name = "Teacher",
                Description = "Teacher"
            };

            var student = new Role()
            {
                Id = 7,
                CreatedOn = DateTime.UtcNow,
                IsActive = true,
                UpdatedOn = DateTime.UtcNow,
                UpdatedById = 1,
                CreatedById = 1,
                Name = "Student",
                Description = "Student"
            };

            var parent = new Role()
            {
                Id = 8,
                CreatedOn = DateTime.UtcNow,
                IsActive = true,
                UpdatedOn = DateTime.UtcNow,
                UpdatedById = 1,
                CreatedById = 1,
                Name = "Parent",
                Description = "Parent"
            };

            builder.HasData(superAdmin, admin, principle, levelHead, hod, teacher, student, parent);

        }
    }
}
