using Microsoft.EntityFrameworkCore;

namespace SearchEngine
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=EfCoreExample;Trusted_Connection=False;" +
                                        "User=sa;Password=MyPass@word;");
        }
    }
}