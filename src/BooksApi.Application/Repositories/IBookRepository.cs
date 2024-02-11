using BooksApi.Core.Entities;

namespace BooksApi.Application.Repositories
{
    public interface IBookRepository 
    {
        public Task CreateBookAsync(Book book);
    }
}