using Microsoft.EntityFrameworkCore;
using SchoolManagement.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Master
{
    public class MasterDBContext : DbContext
    {
        public MasterDBContext()
        {

        }

        public MasterDBContext(DbContextOptions<MasterDBContext> options) : base(options)
        {

        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-4B3H53F;Database=SMMasterDB;Trusted_Connection=True;User Id=sa1;Password=1qaz2wsx@;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new SchoolConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<School> Schools { get; set; }



    }
}
