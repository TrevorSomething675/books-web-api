using BooksApi.Application.Repositories;
using BooksApi.Domain.Entities;

namespace BooksApi.Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        public Task<int> CreateBook(Book bookToCreate)
        {
            throw new NotImplementedException();
        }

        public Task<Book> GetBookById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Book>> GetBooks(uint pageNumber = 1)
        {
            throw new NotImplementedException();
        }
    }
}