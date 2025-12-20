using Microsoft.AspNetCore.Mvc;
using MyFirstDotNetWebApi.Models;
using static System.Reflection.Metadata.BlobBuilder;

namespace MyFirstDotNetWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        static private List<Books> books = new List<Books>
        {
            new Books { Id = 1, Title = "Book One", Author = "Author A" },
            new Books { Id = 2, Title = "Book Two", Author = "Author B" },
            new Books { Id = 3, Title = "Book Three", Author = "Author C" }
        };
        // GET: api/Books
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(books);
        }
        // GET: api/Books/1
        [HttpGet("{id}")]
        public IActionResult GetBookById(int id)
        {
            var book = new { Id = id, Title = "Sample Book", Author = "Sample Author" };
            return Ok(book);
        }
        // POST: api/Books
        [HttpPost]
        public IActionResult CreateBook([FromBody] Books newBook)
        {
            books.Add(newBook);
            return CreatedAtAction(nameof(GetBookById), new { id = newBook.Id }, newBook);
        }
        // PUT: api/Books/1
        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] Books updatedBook)
        {
            var book = books.FirstOrDefault(b => b.Id == id);
            if (book == null)
            {
                return NotFound();
            }
            book.Title = updatedBook.Title;
            book.Author = updatedBook.Author;
            return NoContent();
        }
        // DELETE: api/Books/1
        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            var book = books.FirstOrDefault(b => b.Id == id);
            if (book == null)
            {
                return NotFound();
            }
            books.Remove(book);
            return NoContent();
        }
    }
}
