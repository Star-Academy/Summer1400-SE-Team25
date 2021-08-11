using Microsoft.EntityFrameworkCore;
using SearchEngine.Model.Entities;

namespace SearchEngine.Controller.DataBase
{
    public class Context : DbContext
    {
        public DbSet<Document> Documents { get; set; }
        public DbSet<Word> Words { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=localhost;Database=SearchEngine;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ConfigureDocuments(modelBuilder);
            ConfigureWords(modelBuilder);
        }

        private void ConfigureWords(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Word>().
                HasKey(w => w.WordText);

            modelBuilder.Entity<Word>().
                HasMany(w => w.OccurredDocuments);
        }

        private void ConfigureDocuments(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Document>().
                HasKey(d => d.Id);
        }
    }
}