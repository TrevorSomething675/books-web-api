using BooksApi.Domain.Entities;

namespace BooksApi.Application.Repositories
{
    public interface IBookRepository
    {
        public Task<Book> GetBookByIdAsync(int id);
        public Task<List<Book>> GetBooksAsync(int pageNumber = 1);
        public Task<int> CreateBookAsync(Book bookToCreate);
        public Task<int> UpdateBookAsync(Book bookToUpdate);
        public Task<int> RemoveBookAsync(int id);
    }
}