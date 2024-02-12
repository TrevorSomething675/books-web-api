using BooksApi.Infrastructure.AuthorFeatures.Repositories;
using BooksApi.Infrastructure.BookFeatures.Repositories;
using BooksApi.Application.Repositories;
using Microsoft.EntityFrameworkCore;
using BooksApi.Web.Configurations;
using BooksApi.Infrastructure;
using BooksApi.Core.Entities;
using System.Reflection;
using FluentValidation;

namespace BooksApi.Web
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAppAoptionsConfiguration();
            services.AddAppAutoMapper();
            services.AddDbContextFactory<MainContext>();

            services.AddValidatorsFromAssembly(Assembly.GetAssembly(typeof(AssemblyMarker)));
            services.AddControllers();
            services.AddMediatR(config => config.RegisterServicesFromAssemblies(Assembly.GetAssembly(typeof(AssemblyMarker))));
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IAuthorRepository, AuthorRepository>();

            var dbContextFactory = services.BuildServiceProvider().GetRequiredService<IDbContextFactory<MainContext>>();
            using(var context = dbContextFactory.CreateDbContext())
            {
                if (!context.Authors.Any() && !context.Books.Any())
                {
                    var authors = new List<Author>
                    {
                        new Author {Name = "Author-1" },
                        new Author {Name = "Author-2" },
                        new Author {Name = "Author-3"}
                    };

                    var books = new List<Book>
                    {
                        new Book{ Name = "Book-1", PagesCount = 10,
                            Author = authors.FirstOrDefault(),
                            AuthorId = authors.FirstOrDefault().Id
                        },
                        new Book{ Name = "Book-2", PagesCount = 15,
                            Author = authors.FirstOrDefault(),
                            AuthorId = authors.FirstOrDefault().Id
                        },
                    };
                    context.Authors.AddRange(authors);
                    context.SaveChanges();
                }
            }
        }
        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Book}/{action=GetBooks}");
            });
        }
    }
}
