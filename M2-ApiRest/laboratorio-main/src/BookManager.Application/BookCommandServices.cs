using Azure;
using BookManager.Application.Models;
using BookManager.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging.Abstractions;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;

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
            RegionInfo countryCode;

            try { countryCode = new RegionInfo(author.CountryCode); }
            catch { return -1; }

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
                Description = book.Description,
                AuthorId = book.AuthorId
            };

            _bookDbContext.Books.Add(bookEntity);
            await _bookDbContext.SaveChangesAsync();

            return bookEntity.Id;
        }


        public async Task<int> ModifyBook(int id, string? title, string? description)
        {
            BookEntity? dbBook = _bookDbContext.Books.ToList().Find(x => x.Id == id);

            if (dbBook == null) return -1;

            if(title == null && description == null) return -1;

            if (title != null) dbBook.Title = title;
            if (description != null) dbBook.Description = description;

            _bookDbContext.Books.Update(dbBook);
            await _bookDbContext.SaveChangesAsync();

            return id;
        }

    }
}
