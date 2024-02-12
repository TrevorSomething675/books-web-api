using BooksApi.Application.Repositories;
using Microsoft.EntityFrameworkCore;
using BooksApi.Core.Entities;
using AutoMapper;

namespace BooksApi.Infrastructure.BookFeatures.Repositories
{
    public class BookRepository(
        IDbContextFactory<MainContext> dbContextFactory,
        IMapper mapper
        ) : IBookRepository
    {
        private readonly IDbContextFactory<MainContext> _dbContextFactory = dbContextFactory;

        public async Task<List<Book>> GetBooks()
        {
            using(var context = _dbContextFactory.CreateDbContext())
            {
                var books = context.Books
                    .Include(b => b.Author)
                    .ToList();

                return books;
            }
        }
        
        public async Task<int?> CreateBookAsync(Book book)
        {
            using(var context = _dbContextFactory.CreateDbContext())
            {
                context.Books.Add(book);
                await context.SaveChangesAsync();

                var addedBook = context.Books
                    .AsNoTracking()
                    .FirstOrDefault(b => b.Name == book.Name);

                return addedBook?.Id;
            }
        }

        public async Task<int?> RemoveBookAsync(int id)
        {
            using(var context = _dbContextFactory.CreateDbContext())
            {
                var bookToRemove = context.Books.FirstOrDefault(b => b.Id == id);
                context.Books.Remove(bookToRemove);
                await context.SaveChangesAsync();

                return bookToRemove.Id;
            }
        }
    }
}