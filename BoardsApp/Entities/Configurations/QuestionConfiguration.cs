using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace BoardsApp.Entities.Configurations
{
    public class QuestionConfiguration : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.HasOne(q => q.User)
                .WithMany(u => u.Questions)
                .HasForeignKey(q => q.User.Id)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(q => q.Comments)
                .WithOne(c => c.Question)
                .HasForeignKey(c => c.Question.Id)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(q => q.QuestionTags)
                .WithOne(qt => qt.Question)
                .HasForeignKey(qt => qt.Question.Id)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(q => q.Answers)
                .WithOne(a => a.Question)
                .HasForeignKey(a => a.Question.Id)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
