using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using BooksApi.Domain.Entities;

namespace BooksApi.DataBase.Configuration
{
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasKey(a => a.Id);

            builder.HasMany(a => a.Books)
                .WithOne(b => b.Author);
        }
    }
}