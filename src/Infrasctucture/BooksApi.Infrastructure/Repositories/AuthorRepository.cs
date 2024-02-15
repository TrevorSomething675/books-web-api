using BooksApi.Application.Repositories;
using Microsoft.EntityFrameworkCore;
using BookApi.Infrastructure.Data;
using BooksApi.Domain.Entities;
using BooksApi.Core.AuthorOperations;

namespace BooksApi.Infrastructure.Repositories
{
    public class AuthorRepository(
        IDbContextFactory<MainContext> dbContextFactory
        ) : IAuthorRepository
    {
        private readonly IDbContextFactory<MainContext> _dbContextFactory = dbContextFactory;

        public async Task<Author> GetAuthorByIdAsync(int id)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                var author = context.Authors
                    .AsNoTracking()
                    .FirstOrDefault(a => a.Id == id);
                return author;
            }
        }
        public async Task<List<Author>> GetAuthorsAsync(int pageNumber = 1, int totalAuthorsInPage = 8)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                var authors = await context.Authors
                    .AsNoTracking()
                    .Take(pageNumber * totalAuthorsInPage)
                    .Skip((pageNumber * totalAuthorsInPage) - 1)
                    .ToListAsync();
                return authors;
            }
        }
        public async Task<int> CreateAuthorAsync(Author author)
        {
            using(var context = _dbContextFactory.CreateDbContext())
            {
                var result = context.Authors.Add(author);
                await context.SaveChangesAsync();
                return result.Entity.Id;
            }
        }
        public async Task<int> RemoveAuthorAsync(int id)
        {
            using(var context = _dbContextFactory.CreateDbContext())
            {
                var author = context.Authors.FirstOrDefault(a => a.Id == id);
                var result = context.Authors.Remove(author);
                return result.Entity.Id;
            }
        }
        public async Task<int> UpdateAuthorAsync(Author authorToUpdate)
        {
            using(var context = _dbContextFactory.CreateDbContext())
            {
                var author = context.Authors
                    .FirstOrDefault(a => a.Id == authorToUpdate.Id);

                AuthorUpdate.AuthorUpdateFields(authorToUpdate, out author);
                var result = context.Update(author);
                context.SaveChanges();
                return result.Entity.Id;
            }
        }
    }
}