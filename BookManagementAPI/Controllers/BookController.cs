using Microsoft.AspNetCore.Mvc;
using BookManagementAPI.Models;
using BookManagementAPI.Data;

namespace BookManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private static BookRepository repository = new BookRepository();

        [HttpGet]
        public IActionResult GetAllBooks()
        {
            return Ok(repository.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetBook(int id)
        {
            var book = repository.GetById(id);

            if (book == null)
                return NotFound();

            return Ok(book);
        }

        [HttpPost]
        public IActionResult AddBook([FromBody] Book book)
        {
            repository.Add(book);
            return Ok(book);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] Book book)
        {
            repository.Update(id, book);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            repository.Delete(id);
            return Ok();
        }
    }
}