using BooksApi.Application.Repositories;
using BooksApi.Domain.Entities;

namespace BooksApi.Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        public Task<int> CreateBookAsync(Book bookToCreate)
        {
            throw new NotImplementedException();
        }

        public Task<Book> GetBookByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Book>> GetBooksAsync(uint pageNumber = 1)
        {
            throw new NotImplementedException();
        }
    }
}