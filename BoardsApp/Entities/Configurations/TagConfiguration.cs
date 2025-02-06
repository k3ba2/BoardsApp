using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace BoardsApp.Entities.Configurations
{
    public class TagConfiguration : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.HasMany(t => t.QuestionTags)
                .WithOne(qt => qt.Tag)
                .HasForeignKey(qt => qt.TagId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
