using BookManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;

public interface IBookDbContext
{
    DbSet<BookEntity> Books { get; }
    DbSet<AuthorEntity> Authors { get; }
    Task<int> SaveChangesAsync();
}
