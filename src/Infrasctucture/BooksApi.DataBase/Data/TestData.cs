using BookApi.Infrastructure.Data;
using BooksApi.DataBase.Entities;
using BooksApi.Domain.Enums;

namespace BooksApi.DataBase.Data
{
    internal sealed class TestData
    {
        internal static void SeedData(MainContext context)
        {
            context.Database.EnsureCreated();

            if (!context.Authors.Any())
            {
                var roles = new List<RoleEntity>
                    {
                        new RoleEntity
                        {
                            UserRole = UserRole.User
                        },
                        new RoleEntity
                        {
                            UserRole = UserRole.Admin
                        }
                    };
                context.Roles.AddRange(roles);
                var author1 = new AuthorEntity
                {
                    Name = "author-1",
                    Books = new List<BookEntity>
                        {
                            new BookEntity{
                                Name = "book-1",
                                PagesCount = 5,
                            }
                        }
                };
                var author2 = new AuthorEntity
                {
                    Name = "author-2"
                };
                context.Authors.AddRange(author1, author2);
                context.SaveChanges();
            }

            context.SaveChanges();
        }
    }
}
