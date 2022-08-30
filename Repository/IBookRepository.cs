using System.Collections.Generic;
using System.Threading.Tasks;
using BookStore.API.Models;

namespace BookStore.API.Repository
{
    public interface IBookRepository
    {
        public Task<List<BookModel>> GetAllBooksAsync();
        Task<BookModel> GetBookByIdAsync(int bookId);
        Task<int> AddBookAsync(BookModel bookModel);
        Task UpdateBookAsync(int bookId, BookModel bookModel);
    }
}