using Microsoft.EntityFrameworkCore;

namespace SearchEngine.Model
{
    public class Context : DbContext
    {
        public DbSet<Document> Documents;
        public DbSet<Word> Words;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=EfCoreExample;Trusted_Connection=False;" +
                                        "User=sa;Password=MyPass@word;");
        }
    }
}