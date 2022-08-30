using System.Collections.Generic;
using System.Threading.Tasks;
using BookStore.API.Models;

namespace BookStore.API.Repository
{
    public interface IBookRepository
    {
        public Task<List<BookModel>>  GetAllBooksAsync();
    }
}