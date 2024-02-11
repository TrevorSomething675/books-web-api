using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using BooksApi.Core.OptionModels;

namespace BooksApi.Infrastructure.Data
{
    public class MainContext : DbContext
    {
        private readonly DataBaseOptions _dataBaseOptions;
        public MainContext(DbContextOptions<MainContext> options, IOptions<DataBaseOptions> dataBaseOptions) : base(options)
        {
            _dataBaseOptions = dataBaseOptions.Value;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_dataBaseOptions.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}