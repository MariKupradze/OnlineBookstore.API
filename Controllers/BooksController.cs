
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineBookstore.API.Interfaces;
using OnlineBookstore.API.Models;


namespace OnlineBookstore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;

        public BooksController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public IEnumerable<Book> GetTask()
        {
            return (IEnumerable<Book>)_bookRepository.GetBooks();
        }

        [HttpGet]
        public IEnumerable<Book> Get(IEnumerable<Book> task)
        {
            return task;
        }


        [HttpGet("{id}")]
        public ActionResult<Book> GetById(int id, ActionResult<Book> book)
        {
           // book = _bookRepository.GetBookById(id);

            if (book == null)
            {
                return NotFound();
            }
            else
            {
                return book;
            }

        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult<Book> Create([FromBody] Book book)
        {
            _bookRepository.CreateBook(book);
            return CreatedAtAction(nameof(GetById), new { id = book.BookID }, book);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Update(int id, [FromBody] Book book)
        {
            if (id != book.BookID)
            {
                return BadRequest();
            }

            try
            {
                _bookRepository.UpdateBook(book);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            try
            {
                _bookRepository.DeleteBook(id);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

            return NoContent();
        }
    }
}
