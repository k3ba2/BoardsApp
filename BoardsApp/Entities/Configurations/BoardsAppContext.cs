using Microsoft.EntityFrameworkCore;

namespace BoardsApp.Entities.Configurations
{
    public class BoardsAppContext : DbContext
    {
        public BoardsAppContext(DbContextOptions<DbContext> options) : base(options)
        {
            
        }


    }
}
