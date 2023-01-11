using BookManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Identity.Client.AppConfig;
using System.Reflection.Metadata.Ecma335;

namespace BookManager.Domain
{
    public class BookContext : DbContext
    {
        public BookContext(DbContextOptions<BookContext> options) : base(options) { }

        public DbSet<BookEntity> Books { get; set; } = null;
        public DbSet<AuthorEntity> Authors { get; set; } = null;

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
