using BookApi.Infrastructure.Data;
using BooksApi.Application.Repositories;
using BooksApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BooksApi.Infrastructure.Repositories
{
    public class AuthorRepository(IDbContextFactory<MainContext> dbContextFactory)
        : IAuthorRepository
    {
        private readonly IDbContextFactory<MainContext> _dbContextFactory = dbContextFactory;

        public async Task<Author> GetAuthorBuId(int id)
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
    }
}
