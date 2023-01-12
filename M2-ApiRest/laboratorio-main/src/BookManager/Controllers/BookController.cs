using BookManager.Application;
using BookManager.Application.Models;
using BookManager.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BookManager.Controllers
{
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        [HttpGet]
        public IActionResult Health()
        {
            return Ok();
        }

    }

    [Route("api/[controller]")]
    public class AuthorsController : ControllerBase
    {
        private readonly BookCommandServices _bookCommandServices;


        public AuthorsController ( BookCommandServices bookCommandServices)
        {
            _bookCommandServices = bookCommandServices;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAuthor([FromBody] Author author) {

            var id = await _bookCommandServices.CreateAuthor(author);

            return Ok(id);
        }

    }
}
