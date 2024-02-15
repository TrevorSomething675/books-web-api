using BooksApi.Domain.Entities;

namespace BooksApi.Application.Repositories
{
    public interface IAuthorRepository
    {
        public Task<Author> GetAuthorBuId(int id);
        public Task<List<Author>> GetAuthorsAsync(int pageNumber = 1, int totalAuthorsInPage = 8);
        public Task<int> CreateAuthorAsync(Author author);
    }
}
