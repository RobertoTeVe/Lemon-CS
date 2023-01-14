using BookManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookManager.Domain
{
    public class BookDbContext 
        : DbContext

    {
        public BookDbContext(DbContextOptions<BookDbContext> options) : base(options) { }

        public DbSet<BookEntity> Books { get; set; }/* = null;*/
        public DbSet<AuthorEntity> Authors { get; set; }/* = null;*/
        public Task<int> SaveChangesAsync()
        {
            return base.SaveChangesAsync();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<BookEntity>()
                .HasOne(a => a.Author)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
