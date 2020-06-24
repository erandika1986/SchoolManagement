using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagement.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Data.Configurations
{
    public class BasketSubjectConfiguration : IEntityTypeConfiguration<BasketSubject>
    {
        public void Configure(EntityTypeBuilder<BasketSubject> builder)
        {
            //builder.ToTable("BasketSubject", Schema.MASTER);

            //builder.HasKey(x => new { x.ParentBasketCategoryId,x.BasketSubjecId});

            //builder
            //    .HasOne<Subject>(c => c.Subject)
            //    .WithMany(r => r.BasketSubjects)
            //    .HasForeignKey(s => s.BasketSubjecId).OnDelete(DeleteBehavior.Restrict);

            //builder
            //    .HasOne<Subject>(c => c.ParentBasketSubject)
            //    .WithMany(r => r.ParentBasketSubjects)
            //    .HasForeignKey(s => s.ParentBasketCategoryId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
