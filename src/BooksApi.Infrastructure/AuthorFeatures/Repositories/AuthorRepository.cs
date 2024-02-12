using BooksApi.Application.Repositories;
using Microsoft.EntityFrameworkCore;
using BooksApi.Core.Entities;

namespace BooksApi.Infrastructure.AuthorFeatures.Repositories
{
    public class AuthorRepository(
        IDbContextFactory<MainContext> dbContextFactory
        ) : IAuthorRepository
    {
        private readonly IDbContextFactory<MainContext> _dbContextFactory = dbContextFactory;

        public async Task<int?> CreateAuthor(Author author)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                context.Authors.Add(author);
                await context.SaveChangesAsync();
                var addedAuthorId = context.Authors.FirstOrDefault(a => a.Name == author.Name)?.Id;
                return addedAuthorId;
            }
        }
    }
}