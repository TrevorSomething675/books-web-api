using BooksApi.Domain.Entities;

namespace BooksApi.Application.Repositories
{
    public interface IBookRepository
    {
        public Task<Book> GetBookById(int id);
        public Task<List<Book>> GetBooks(uint pageNumber = 1);
        public Task<int> CreateBook(Book bookToCreate);
    }
}