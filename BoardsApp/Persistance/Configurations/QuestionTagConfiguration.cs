﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace BoardsApp.Entities.Configurations
{
    public class QuestionTagConfiguration : IEntityTypeConfiguration<QuestionTag>
    {
        public void Configure(EntityTypeBuilder<QuestionTag> builder)
        {
            builder.HasKey(qt => new {qt.QuestionId, qt.TagId});

            builder.HasOne(qt => qt.Question)
                .WithMany(q => q.QuestionTags)
                .HasForeignKey(qt => qt.QuestionId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(qt => qt.Tag)
                .WithMany(t => t.QuestionTags)
                .HasForeignKey(qt => qt.TagId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(qt => qt.CreatedDate)
                .HasDefaultValueSql("GETDATE()");
        }
    }
}
