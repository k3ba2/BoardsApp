using Microsoft.EntityFrameworkCore;

namespace BoardsApp.Entities
{
    public class BoardsAppContext : DbContext
    {
        public BoardsAppContext(DbContextOptions<DbContext> options) : base(options)
        {

        }

        public DbSet<Answer> Answers { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Question> Question { get; set; }   

        public DbSet<AnswerLike> Scores { get; set; }    

        public DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        }
    }
}




//question - każde pytanie może mieć komentarze, mogą mieć wiele tagów, wiele odpowiedzi
//answer - każda odpowiedź może mieć komentarze, każda może mieć punkty
//comment
//tag
//user
//commentlike
//questiontag