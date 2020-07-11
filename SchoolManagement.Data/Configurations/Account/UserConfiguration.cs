using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagement.Model;
using SchoolManagement.Util;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Data.Configurations
{
    public class UserConfiguration: IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User", Schema.ACCOUNT);

            builder.HasKey(x => x.Id);

            builder.HasIndex(r => r.Username).IsUnique();

            builder.HasIndex(r => r.Email).IsUnique();

            builder
                .HasOne<User>(s => s.CreatedBy)
                .WithMany(r => r.CreatedUsers)
                .HasForeignKey(s => s.CreatedById).OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne<User>(s => s.UpdatedBy)
                .WithMany(r => r.UpdatedUsers)
                .HasForeignKey(s => s.UpdatedById).OnDelete(DeleteBehavior.Restrict);

            var superAdmin = new User()
            {
                Id=1,
                FullName = "SuperAdmin",
                NickName = "SuperAdmin",
                Email = "erandika1986@gmail.com",
                Username = "erandika1986@gmail.com",
                MobileNo = "0702605650",
                Password = CustomPasswordHasher.GenerateHash("pass@123!"),
                IsActive = true,
                CreatedOn = DateTime.UtcNow,
                UpdatedOn = DateTime.UtcNow
            };

            var admin = new User()
            {
                Id=2,
                FullName = "Admin",
                NickName = "Admin",
                Email = "erandika.du@gmail.com",
                Username = "erandika.du@gmail.com",
                MobileNo = "0702605651",
                Password = CustomPasswordHasher.GenerateHash("pass@123!"),
                IsActive = true,
                CreatedOn = DateTime.UtcNow,
                UpdatedOn = DateTime.UtcNow
            };

            builder.HasData(superAdmin, admin);

        }
    }
}
