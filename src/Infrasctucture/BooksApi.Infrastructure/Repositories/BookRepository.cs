using BooksApi.Application.Repositories;
using Microsoft.EntityFrameworkCore;
using BookApi.Infrastructure.Data;
using BooksApi.Domain.Entities;

namespace BooksApi.Infrastructure.Repositories
{
    public class BookRepository(IDbContextFactory<MainContext> dbContextFactory) : IBookRepository
    {
        private readonly IDbContextFactory<MainContext> _dbContextFactory = dbContextFactory;
        public async Task<Book> GetBookByIdAsync(int id)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                var book = await context.Books
                    .AsNoTracking()
                    .FirstOrDefaultAsync(b => b.Id == id);

                return book;
            }
        }
        public async Task<List<Book>> GetBooksAsync(int pageNumber = 1)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                var books = await context.Books
                    .AsNoTracking()
                    .ToListAsync();

                return books;
            }
        }
        public async Task<int> CreateBookAsync(Book bookToCreate)
        {
            using(var context = _dbContextFactory.CreateDbContext())
            {
                var result = context.Books.Add(bookToCreate);
                await context.SaveChangesAsync();
                return result.Entity.Id;
            }
        }
        public async Task<int> UpdateBookAsync(Book bookToUpdate)
        {
            using(var context = _dbContextFactory.CreateDbContext())
            {
                var book = await context.Books.FirstOrDefaultAsync();
                context.Entry(book).OriginalValues.SetValues(bookToUpdate);
                return book.Id;
            }
        }
        public async Task<int> RemoveBookAsync(int id)
        {
            using(var context = _dbContextFactory.CreateDbContext())
            {
                var book = await context.Books.FirstOrDefaultAsync(b => b.Id == id);
                var result = context.Remove(book);
                await context.SaveChangesAsync();
                return result.Entity.Id;
            }
        }
    }
}