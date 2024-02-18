using BooksApi.Infrastructure.Repositories;
using BooksApi.Application.Repositories;
using BookApi.Infrastructure.Data;
using BooksApi.Web.Configurations;
using BooksApi.Core.OptionModels;
using BooksApi.Domain.Entities;
using System.Reflection;
using FluentValidation;

namespace BooksApi.Web
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            var configuration = services.BuildServiceProvider().GetRequiredService<IConfiguration>();
            services.Configure<DataBaseOptions>(configuration.GetSection(DataBaseOptions.SectionName));

            services.AddAppAutoMapper();

            services.AddControllers();
            services.AddDbContextFactory<MainContext>();
            services.AddMediatR(config => config.RegisterServicesFromAssemblies(Assembly.GetAssembly(typeof(Infrastructure.AssemblyMarker))));
            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddValidatorsFromAssembly(Assembly.GetAssembly(typeof(Infrastructure.AssemblyMarker)));
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            using (var scope = app.ApplicationServices.CreateScope()) 
            {
                using(var context = scope.ServiceProvider.GetRequiredService<MainContext>())
                {
                    if(!context.Authors.Any())
                    {
                        var author1 = new Author
                        {
                            Name = "author-1"
                        };
                        var author2 = new Author
                        {
                            Name = "author-2"
                        };
                        context.Authors.AddRange(author1, author2);
                        context.SaveChanges();
                    }
                }
            }
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