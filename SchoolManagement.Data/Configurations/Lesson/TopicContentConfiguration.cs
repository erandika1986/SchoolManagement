using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagement.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Data.Configurations
{
    public class TopicContentConfiguration : IEntityTypeConfiguration<TopicContent>
    {
        public void Configure(EntityTypeBuilder<TopicContent> builder)
        {
            builder.ToTable("TopicContent", Schema.LESSON);

            builder.HasKey(x => x.Id);
        }
    }
}
