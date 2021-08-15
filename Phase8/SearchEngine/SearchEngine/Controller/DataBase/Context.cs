using Microsoft.EntityFrameworkCore;
using SearchEngine.Model.Entities;

namespace SearchEngine.Controller.DataBase
{
    public class Context : DbContext
    {
        public DbSet<Document> Documents { get; set; }
        public DbSet<Word> Words { get; set; }
        public DbSet<WordDocument> WordDocuments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=.;Database=SearchEngine;Trusted_Connection=False;" +
                                        "User=sa;Password=MyPass@word;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ConfigureDocuments(modelBuilder);
            ConfigureWords(modelBuilder);
            ConfigureRelations(modelBuilder);
        }

        private void ConfigureWords(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Word>().
                HasKey(w => w.Id);
        }

        private void ConfigureDocuments(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Document>().
                HasKey(d => d.Id);
        }

        private void ConfigureRelations(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WordDocument>().
                HasOne(wd => wd.Document).
                WithMany(d => d.WordDocuments).
                HasForeignKey(wd => wd.DocumentId);
            modelBuilder.Entity<WordDocument>().
                HasOne(wd => wd.Word).
                WithMany(w => w.WordDocuments).
                HasForeignKey(wd => wd.WordId);
            modelBuilder.Entity<WordDocument>().
                HasKey(wd => new { wd.DocumentId, wd.WordId });
        }
    }
}