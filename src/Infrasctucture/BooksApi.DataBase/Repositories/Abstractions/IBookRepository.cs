using BooksApi.Application.Models;

namespace BooksApi.DataBase.Repositories.Abstractions
{
    public interface IBookRepository
    {
        public Task<Book> GetBookByIdAsync(int id);
        public Task<List<Book>> GetBooksAsync(int pageNumber = 1);
        public Task<int> CreateBookAsync(Book book);
        public Task<int> UpdateBookAsync(Book book);
        public Task<int> RemoveBookAsync(int id);
    }
}
