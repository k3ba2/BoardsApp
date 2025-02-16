using Microsoft.EntityFrameworkCore;

namespace BoardsApp.Entities
{
    public class BoardsAppContext : DbContext
    {
        public BoardsAppContext(DbContextOptions<BoardsAppContext> options) : base(options)
        {

        }

        public DbSet<Answer> Answers { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Question> Question { get; set; }   

        public DbSet<QuestionTag> QuestionTags { get; set; }

        public DbSet<AnswerLike> Scores { get; set; }    

        public DbSet<Tag> Tags { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        }
    }
}