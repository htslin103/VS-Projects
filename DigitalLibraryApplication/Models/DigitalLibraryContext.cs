using Microsoft.EntityFrameworkCore;
namespace DigitalLibraryApplication.Models
{
    public class DigitalLibraryContext: DbContext
    {
        public DigitalLibraryContext(): base() { }
        public DigitalLibraryContext(DbContextOptions<DigitalLibraryContext> options) : base(options) { }

        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Publisher> Publishers { get; set; } 
        public virtual DbSet<Audiobook> Audiobooks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().ToTable("Author");
            modelBuilder.Entity<Publisher>().ToTable("Publisher");
            modelBuilder.Entity<Audiobook>().ToTable("Audiobook");
        }
    }
}