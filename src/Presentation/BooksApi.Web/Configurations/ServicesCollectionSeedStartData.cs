using BookApi.Infrastructure.Data;
using BooksApi.DataBase.Entities;
using BooksApi.Core.Enums;

namespace BooksApi.Web.Configurations
{
    public static class ServicesCollectionSeedStartData
    {
        public static void SeedTestData(this IServiceCollection services)
        {
            var context = services.BuildServiceProvider().GetRequiredService<MainContext>();

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