using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
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
        [HttpGet]
        public ActionResult<List<Books>> GetAllBooks()
        {
            return Ok(books);
        }

        [HttpGet("{id}")]
        public ActionResult<Books> GetBookById(int id)
        {
            var book = books.FirstOrDefault(b => b.Id == id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }
        [HttpPost]
        public ActionResult<Books> CreateBook([FromBody] Books newBook)
        {
            newBook.Id = books.Max(b => b.Id) + 1;
            books.Add(newBook);
            return CreatedAtAction(nameof(GetBookById), new { id = newBook.Id }, newBook);
        }
    }
}
