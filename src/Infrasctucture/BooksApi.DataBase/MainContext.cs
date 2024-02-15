using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using BooksApi.Core.OptionModels;
using BooksApi.Domain.Entities;

namespace BookApi.Infrastructure.Data
{
    public class MainContext : DbContext
    {
        private readonly DataBaseOptions _dbOptions;
        public MainContext(
            DbContextOptions<MainContext> options,
            IOptions<DataBaseOptions> dbOptions
            ) : base(options)
        {
            _dbOptions = dbOptions.Value;
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_dbOptions.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new BrandConfiguration());
        }
    }
}