using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using BooksApi.Domain.Entities;

namespace BooksApi.DataBase.Configuration
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(b => b.Id);

            builder.HasOne(b => b.Author)
                .WithMany(a => a.Books)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
