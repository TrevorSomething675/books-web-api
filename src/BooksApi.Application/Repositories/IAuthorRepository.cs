using BooksApi.Core.Entities;

namespace BooksApi.Application.Repositories
{
    public interface IAuthorRepository
    {
        public Task<int?> CreateAuthor(Author author);
    }
}
