using Microsoft.EntityFrameworkCore;
using SearchEngine.Model.Entities;

namespace SearchEngine.Controller.DataBase
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