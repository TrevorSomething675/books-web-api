using BooksApi.Core.WebModels;

namespace BooksApi.Application.Repositories
{
    public interface IBookRepository 
    {
        public Task CreateBookAsync(BookRequest bookDto);
    }
}