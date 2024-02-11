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
                var entityToRemove = context.Books.FirstOrDefault(b => b.Id == book.Id);
                context.Books.Remove(entityToRemove);
                await context.SaveChangesAsync();
            }
        }
        public async Task RemoveBookAsync(int id)
        {

        }
    }
}