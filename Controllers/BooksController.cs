using Microsoft.AspNetCore.Mvc;
using BookStore.API.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookStore.API.Models;

namespace BookStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;

        public BooksController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        // Return all books
        [HttpGet("")]
        public async Task<IActionResult> GetAllBooks()
        {
            var books = await _bookRepository.GetAllBooksAsync();
            return Ok(books);
        }

        // Return a book
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById(int id)
        {
            var book = await _bookRepository.GetBookByIdAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        // Add a new book
        [HttpPost("")]
        public async Task<IActionResult> AddNewBook([FromBody] BookModel bookModel)
        {
            var id = await _bookRepository.AddBookAsync(bookModel);
            return CreatedAtAction(nameof(GetBookById), new { id = id, controller = "books" }, id);
        }

        // Update a book
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook([FromBody] BookModel bookModel, [FromRoute] int id)
        {
            await _bookRepository.UpdateBookAsync(id, bookModel);
            return Ok();
        }
    }

}