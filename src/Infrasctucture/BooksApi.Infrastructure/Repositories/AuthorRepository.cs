using BooksApi.Application.Repositories;
using Microsoft.EntityFrameworkCore;
using BookApi.Infrastructure.Data;
using BooksApi.Domain.Entities;

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
                    .Skip((pageNumber - 1) * totalAuthorsInPage)
                    .ToListAsync();
                return authors;
            }
        }
        public async Task<int> CreateAuthorAsync(Author authorToCreate)
        {
            using(var context = _dbContextFactory.CreateDbContext())
            {
                var result = context.Authors.Add(authorToCreate);
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
                await context.SaveChangesAsync();
                return result.Entity.Id;
            }
        }
        public async Task<int> UpdateAuthorAsync(Author authorToUpdate)
        {
            using(var context = _dbContextFactory.CreateDbContext())
            {
                var author = context.Authors
                    .Include(a => a.Books)
                    .FirstOrDefault(a => a.Id == authorToUpdate.Id);

                if (author != null)
                {
                    var authorBooks = author.Books.ToList();
                    if(author.Books.Count < authorToUpdate.Books.Count)
                    {
                        foreach (var bookToAdd in authorToUpdate.Books)
                        {
                            var selectedBook = author.Books.FirstOrDefault(b => b.Name == bookToAdd.Name);
                            if (selectedBook == null)
                                author.Books.Add(bookToAdd);
                        }
                    } 
                    else if(author.Books.Count > authorToUpdate.Books.Count)
                    {
                        foreach (var bookToRemove in authorBooks)
                        {
                            var selectedBook = authorToUpdate.Books.FirstOrDefault(b => b.Name == bookToRemove.Name);
                            if(selectedBook != null)
                                author.Books.Remove(bookToRemove);
                        }
                    }
                    context.Entry(author).OriginalValues.SetValues(authorToUpdate);
                    await context.SaveChangesAsync();
                    return authorToUpdate.Id;
                }
                throw new Exception("Автор не найден");
            }
        }
    }
}