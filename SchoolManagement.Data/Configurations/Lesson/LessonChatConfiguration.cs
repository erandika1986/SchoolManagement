using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagement.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Data
{
    public class LessonChatConfiguration : IEntityTypeConfiguration<LessonChat>
    {
        public void Configure(EntityTypeBuilder<LessonChat> builder)
        {
            builder.ToTable("LessonChat", Schema.LESSON);

            builder.HasKey(x => x.Id);

            builder
                .HasOne<Lesson>(s => s.Lesson)
                .WithMany(r => r.LessonChats)
                .HasForeignKey(s => s.LessonId).OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne<Topic>(s => s.Topic)
                .WithMany(r => r.LessonChats)
                .HasForeignKey(s => s.TopicId).OnDelete(DeleteBehavior.Restrict).IsRequired(false) ;

            builder
                .HasOne<User>(s => s.FromUser)
                .WithMany(r => r.LessonChatsFrom)
                .HasForeignKey(s => s.FromUserId).OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne<User>(s => s.ToUser)
                .WithMany(r => r.LessonChatsTo)
                .HasForeignKey(s => s.ToUserId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
