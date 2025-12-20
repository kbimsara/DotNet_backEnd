using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyFirstDotNetWebApi.Data;
using MyFirstDotNetWebApi.Models;

namespace MyFirstDotNetWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BooksContext _context;

        public BooksController(BooksContext context)
        {
            _context = context;
        }
        // GET: api/Books
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var books = await _context.Books.ToListAsync();
            return Ok(books);
        }
        // GET: api/Books/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }
        // POST: api/Books
        [HttpPost]
        public async Task<IActionResult> CreateBook([FromBody] Books newBook)
        {
            newBook.PublishedDate = DateTime.UtcNow;

            _context.Books.Add(newBook);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetBookById),
                new { id = newBook.Id }, newBook);
        }

        // PUT: api/Books/1
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, [FromBody] Books updatedBook)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            book.Title = updatedBook.Title;
            book.Author = updatedBook.Author;


            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await BookExists(id))
                {
                    return NotFound();
                }
                throw;
            }

            return NoContent();
        }
        // DELETE: api/Books/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private async Task<bool> BookExists(int id)
        {
            return await _context.Books.AnyAsync(e => e.Id == id);
        }
    }
}
