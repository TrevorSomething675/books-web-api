using BooksApi.DataBase.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using BooksApi.DataBase.Entities;
using BooksApi.Core.OptionModels;
using BooksApi.DataBase.Data;

namespace BookApi.Infrastructure.Data
{
    public class MainContext : DbContext
    {
        private readonly DataBaseOptions _dbOptions;
        public MainContext(IOptions<DataBaseOptions> dbOptions)
        {
            _dbOptions = dbOptions.Value;
        }

        public DbSet<AuthorEntity> Authors { get; set; }
        public DbSet<BookEntity> Books { get; set; }
        public DbSet<RoleEntity> Roles { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_dbOptions.ConnectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            TestData.SeedData(this);
            modelBuilder.ApplyConfiguration(new AuthorConfiguration());
            modelBuilder.ApplyConfiguration(new BookConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
        }
    }
}