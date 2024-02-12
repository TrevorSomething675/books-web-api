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
        public async Task CreateBookAsync(Book book)
        {
            using(var context = _dbContextFactory.CreateDbContext())
            {
                context.Books.Add(book);
                await context.SaveChangesAsync();
            }
        }
        public async Task RemoveBookAsync(int id)
        {

        }
    }
}