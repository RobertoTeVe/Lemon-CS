using BookManager.Application;
using BookManager.Application.Models;
using BookManager.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BookManager.Controllers
{
    [Route("api")]
    public class BookManagerController 
        : ControllerBase
    {
        private readonly BookCommandServices _bookCommandServices;
        public BookManagerController(BookCommandServices bookCommandServices)
        {
            _bookCommandServices = bookCommandServices;
        }


        [HttpGet]
        public IActionResult Health()
        {
            return Ok();
        }


        [HttpPost("books")]
        public async Task<IActionResult> CreateBook([FromBody] Book book)
        {
            var id = await _bookCommandServices.CreateBook(book);

            return Ok(id);
        }


        [HttpPut("books/{id:int}")]
        public async Task<IActionResult> ModifyBook(int id, [FromBody] Book book)
        {
            var modifiedBookId = await _bookCommandServices.ModifyBook(id, book.Title, book.Description);

            if (modifiedBookId == -1) return StatusCode(400);

            return Ok(modifiedBookId);
        }


        [HttpPost("authors")]
        public async Task<IActionResult> CreateAuthor([FromBody] Author author)
        {

            var id = await _bookCommandServices.CreateAuthor(author);

            // '-1' is returned when the countrycode is not valid.
            if (id == -1) return StatusCode(400);

            return Ok(id);
        }
    }
}
