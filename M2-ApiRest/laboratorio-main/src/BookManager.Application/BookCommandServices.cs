using BookManager.Application.Models;
using BookManager.Domain.Entities;

namespace BookManager.Application
{
    public class BookCommandServices
    {
        private readonly IBookDbContext _bookDbContext;

        public BookCommandServices(IBookDbContext bookContext)
        {
            _bookDbContext = bookContext;
        }

        public async Task<int> CreateAuthor(Author author)
        {
            var authorEntity = new AuthorEntity
            {
                Name = author.Name,
                LastName = author.LastName,
                Birth = author.Birth,
                CountryCode = author.CountryCode
            };

            _bookDbContext.Authors.Add(authorEntity);
            await _bookDbContext.SaveChangesAsync();

            return authorEntity.Id;
        }

        public async Task<int> CreateBook(Book book)
        {
            var bookEntity = new BookEntity
            {
                Title = book.Title,
                PublishedOn = book.PublishedOn,
                Description= book.Description,
                AuthorId= book.AuthorId
            };

            _bookDbContext.Books.Add(bookEntity);
            await _bookDbContext.SaveChangesAsync();

            return bookEntity.Id;
        }

    }
}
