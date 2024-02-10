using BooksApi.Application.Repositories;
using BooksApi.Core.WebModels;

namespace BooksApi.Infrastructure.Book.Repositories
{
    public class BookRepository : IBookRepository
    {
        public async Task CreateBookAsync(BookRequest bookDto)
        {

        }
    }
}