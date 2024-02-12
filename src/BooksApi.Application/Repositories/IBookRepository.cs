using BooksApi.Core.Entities;

namespace BooksApi.Application.Repositories
{
    public interface IBookRepository 
    {
        public Task<List<Book>> GetBooks();
        public Task<int?> CreateBookAsync(Book book);
        public Task<int?> RemoveBookAsync(int id);
    }
}