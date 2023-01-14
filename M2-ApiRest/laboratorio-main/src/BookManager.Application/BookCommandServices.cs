using BookManager.Application.Models;
using BookManager.Domain;
using BookManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.Application
{
    public class BookCommandServices
    {
        private readonly BookDbContext _bookContext;

        public BookCommandServices(BookDbContext bookContext)
        {
            _bookContext = bookContext;
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

            _bookContext.Authors.Add(authorEntity);
            await _bookContext.SaveChangesAsync();

            return authorEntity.Id;
        }

    }
}
