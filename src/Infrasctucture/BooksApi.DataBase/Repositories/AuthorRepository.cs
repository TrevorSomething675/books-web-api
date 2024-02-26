using BooksApi.DataBase.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;
using BookApi.Infrastructure.Data;
using BooksApi.Application.Models;
using BooksApi.DataBase.Entities;
using AutoMapper;


namespace BooksApi.DataBase.Repositories
{
    public class AuthorRepository(
            IDbContextFactory<MainContext> dbContextFactory,
            IMapper mapper
            ) : IAuthorRepository
    {
        private readonly IMapper _mapper = mapper;
        private readonly IDbContextFactory<MainContext> _dbContextFactory = dbContextFactory;
        public async Task<Author> GetAuthorByIdAsync(int id)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                var author = context.Authors
                    .AsNoTracking()
                    .FirstOrDefault(a => a.Id == id);

                return _mapper.Map<Author>(author);
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
                return _mapper.Map<List<Author>>(authors);
            }
        }
        public async Task<int> CreateAuthorAsync(Author author)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                var authorEntity = _mapper.Map<AuthorEntity>(author);
                var result = context.Authors.Add(authorEntity);
                await context.SaveChangesAsync();
                return result.Entity.Id;
            }
        }
        public async Task<int> RemoveAuthorAsync(int id)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                var author = context.Authors.FirstOrDefault(a => a.Id == id);
                var result = context.Authors.Remove(author);
                await context.SaveChangesAsync();
                return result.Entity.Id;
            }
        }
        public async Task<int> UpdateAuthorAsync(Author author)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                var authorToUpdate = _mapper.Map<AuthorEntity>(author);
                var authorEntity = context.Authors
                    .Include(a => a.Books)
                    .FirstOrDefault(a => a.Id == authorToUpdate.Id);

                if (authorEntity != null)
                {
                    var authorBooks = authorEntity.Books.ToList();
                    if (authorEntity.Books.Count < authorToUpdate.Books.Count)
                    {
                        foreach (var bookToAdd in authorToUpdate.Books)
                        {
                            var selectedBook = authorEntity.Books.FirstOrDefault(b => b.Name == bookToAdd.Name);
                            if (selectedBook == null)
                                authorEntity.Books.Add(bookToAdd);
                        }
                    }
                    else if (authorEntity.Books.Count > authorToUpdate.Books.Count)
                    {
                        foreach (var bookToRemove in authorBooks)
                        {
                            var selectedBook = authorToUpdate.Books.FirstOrDefault(b => b.Name == bookToRemove.Name);
                            if (selectedBook != null)
                                authorEntity.Books.Remove(bookToRemove);
                        }
                    }
                    context.Entry(authorEntity).OriginalValues.SetValues(authorToUpdate);
                    await context.SaveChangesAsync();
                    return authorToUpdate.Id;
                }
                throw new Exception("Автор не найден");
            }
        }
    }
}
