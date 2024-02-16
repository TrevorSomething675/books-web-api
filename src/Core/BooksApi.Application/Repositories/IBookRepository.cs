using BooksApi.Domain.Entities;

namespace BooksApi.Application.Repositories
{
    public interface IBookRepository
    {
        public Task<Book> GetBookByIdAsync(int id);
        public Task<List<Book>> GetBooksAsync(uint pageNumber = 1);
        public Task<int> CreateBookAsync(Book bookToCreate);
    }
}