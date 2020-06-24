using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagement.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Data.Configurations
{
    public class MCQAnswerConfiguration : IEntityTypeConfiguration<MCQAnswer>
    {
        public void Configure(EntityTypeBuilder<MCQAnswer> builder)
        {
            builder.ToTable("MCQAnswer", Schema.LESSON);

            builder.HasKey(x => x.Id);

            builder
            .HasOne<Question>(s => s.Question)
            .WithMany(r => r.MCQAnswers)
            .HasForeignKey(s => s.QuestonId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}

