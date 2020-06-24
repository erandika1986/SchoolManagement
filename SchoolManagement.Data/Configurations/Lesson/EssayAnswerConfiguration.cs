using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagement.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Data.Configurations
{
    public class EssayAnswerConfiguration : IEntityTypeConfiguration<EssayAnswer>
    {
        public void Configure(EntityTypeBuilder<EssayAnswer> builder)
        {
            builder.ToTable("EssayAnswer", Schema.LESSON);

            builder.HasKey(x => x.Id);

            builder
                .HasOne<Question>(s => s.Question)
                .WithMany(r => r.EssayAnswers)
                .HasForeignKey(s => s.QuestonId).OnDelete(DeleteBehavior.Restrict);
        }


    }
}
