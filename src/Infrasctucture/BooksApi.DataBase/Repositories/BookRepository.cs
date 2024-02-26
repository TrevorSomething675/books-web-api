using BooksApi.DataBase.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;
using BookApi.Infrastructure.Data;
using BooksApi.DataBase.Entities;
using BooksApi.Application.Models;
using AutoMapper;

namespace BooksApi.DataBase.Repositories
{
    public class BookRepository(
        IDbContextFactory<MainContext> dbContextFactory,
        IMapper mapper
        ) : IBookRepository
    {
        private readonly IMapper _mapper = mapper;
        private readonly IDbContextFactory<MainContext> _dbContextFactory = dbContextFactory;
        public async Task<Book> GetBookByIdAsync(int id)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                var book = await context.Books
                    .AsNoTracking()
                    .FirstOrDefaultAsync(b => b.Id == id);

                return _mapper.Map<Book>(book);
            }
        }
        public async Task<List<Book>> GetBooksAsync(int pageNumber = 1)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                var books = await context.Books
                    .AsNoTracking()
                    .ToListAsync();

                return _mapper.Map<List<Book>>(books);
            }
        }
        public async Task<int> CreateBookAsync(Book book)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                var bookEntity = _mapper.Map<BookEntity>(book);
                var result = context.Books.Add(bookEntity);
                await context.SaveChangesAsync();
                return result.Entity.Id;
            }
        }
        public async Task<int> UpdateBookAsync(Book book)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                var bookEntityToUpdate = _mapper.Map<Book>(book);
                var bookEntity = await context.Books.FirstOrDefaultAsync();
                context.Entry(book).OriginalValues.SetValues(bookEntityToUpdate);
                return book.Id;
            }
        }
        public async Task<int> RemoveBookAsync(int id)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                var book = await context.Books.FirstOrDefaultAsync(b => b.Id == id);
                var result = context.Remove(book);
                await context.SaveChangesAsync();
                return result.Entity.Id;
            }
        }
    }
}
