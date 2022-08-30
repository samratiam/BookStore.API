using BookStore.API.Data;
using BookStore.API.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;


namespace BookStore.API.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly BookStoreContext _context;
        public BookRepository(BookStoreContext context)
        {
            _context = context;
        }

        // Get all books
        public async Task<List<BookModel>> GetAllBooksAsync()
        {
            var records = await _context.Books.Select(x => new BookModel()
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description
            }).ToListAsync();

            return records;
        }

        // Get a single book
        public async Task<BookModel> GetBookByIdAsync(int bookId)
        {
            var record = await _context.Books.Where(x => x.Id == bookId).Select(x => new BookModel()
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description
            }).FirstOrDefaultAsync();

            return record;
        }

        // Add a new book
        public async Task<int> AddBookAsync(BookModel bookModel)
        {
            var book = new Books()
            {
                Title = bookModel.Title,
                Description = bookModel.Description
            };
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return book.Id;
        }
    }
}