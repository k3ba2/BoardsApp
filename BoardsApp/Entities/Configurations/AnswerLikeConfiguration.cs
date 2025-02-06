using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BoardsApp.Entities.Configurations
{
    public class AnswerLikeConfiguration : IEntityTypeConfiguration<AnswerLike>
    {
        public void Configure(EntityTypeBuilder<AnswerLike> builder)
        {
            builder.HasOne(al => al.Answer)
                .WithMany(a => a.AnswerLikes)
                .HasForeignKey(al => al.AnswerId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(al => al.User)
                .WithMany(u => u.AnswerLikes)
                .HasForeignKey(al => al.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
