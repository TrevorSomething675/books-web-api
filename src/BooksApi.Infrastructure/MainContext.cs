using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using BooksApi.Core.OptionModels;
using BooksApi.Core.Entities;

namespace BooksApi.Infrastructure
{
    public class MainContext : DbContext
    {
        private readonly DataBaseOptions _dataBaseOptions;
        public MainContext(DbContextOptions<MainContext> options, 
            IOptions<DataBaseOptions> dataBaseOptions) : base(options)
        {
            _dataBaseOptions = dataBaseOptions.Value;
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_dataBaseOptions.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}