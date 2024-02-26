using BooksApi.Application.Models;

namespace BooksApi.DataBase.Repositories.Abstractions
{
    public interface IAuthorRepository
    {
        public Task<Author> GetAuthorByIdAsync(int id);
        public Task<List<Author>> GetAuthorsAsync(int pageNumber = 1, int totalAuthorsInPage = 8);
        public Task<int> CreateAuthorAsync(Author author);
        public Task<int> UpdateAuthorAsync(Author author);
        public Task<int> RemoveAuthorAsync(int id);
    }
}
