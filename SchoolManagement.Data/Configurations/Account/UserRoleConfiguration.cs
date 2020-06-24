using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagement.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Data.Configurations
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.ToTable("UserRole", Schema.ACCOUNT);

            builder.HasKey(x => new { x.UserId,x.RoleId });

            builder
                .HasOne<Role>(s => s.Role)
                .WithMany(r => r.UserRoles)
                .HasForeignKey(s => s.RoleId).OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne<User>(s => s.User)
                .WithMany(r => r.UserRoles)
                .HasForeignKey(s => s.UserId).OnDelete(DeleteBehavior.Restrict);


            builder
                .HasOne<User>(s => s.CreatedBy)
                .WithMany(r => r.CreatedUserRoles)
                .HasForeignKey(s => s.CreatedById).OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne<User>(s => s.UpdatedBy)
                .WithMany(r => r.UpdatedUserRoles)
                .HasForeignKey(s => s.UpdatedById).OnDelete(DeleteBehavior.Restrict);

            var superAdminRole = new UserRole() 
            { 
                CreatedOn = DateTime.UtcNow, 
                UpdatedOn = DateTime.UtcNow, 
                IsActive = true, 
                RoleId = 1, 
                UserId = 1,
                UpdatedById = 1,
                CreatedById = 1,
            };
            var adminRole = new UserRole() 
            { 
                CreatedOn = DateTime.UtcNow, 
                UpdatedOn = DateTime.UtcNow, 
                IsActive = true, 
                RoleId = 2, 
                UserId = 2,
                UpdatedById = 1,
                CreatedById = 1,
            };

            builder.HasData(superAdminRole,adminRole);
        }
    }
}
