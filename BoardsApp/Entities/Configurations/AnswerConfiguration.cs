using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BoardsApp.Entities.Configurations
{
    public class AnswerConfiguration : IEntityTypeConfiguration<Answer> 
    {
        public void Configure(EntityTypeBuilder<Answer> builder) 
        {
            builder.HasOne(a => a.Question)
                .WithMany(q => q.Answers)
                .HasForeignKey(a => a.QuestionId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(a => a.User)
                .WithMany(u => u.Answers)
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(a => a.Message)
                .IsRequired()
                .HasMaxLength(1000);
        }
    }
}
