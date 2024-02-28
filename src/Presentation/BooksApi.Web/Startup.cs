using BooksApi.Core.Abstractions.Repositories;
using BooksApi.Infrastructure.Services;
using BooksApi.DataBase.Repositories;
using BooksApi.Application.Services;
using BookApi.Infrastructure.Data;
using BooksApi.Web.Configurations;
using BooksApi.Core.OptionModels;
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
            services.Configure<JwtAuthOptions>(configuration.GetSection(JwtAuthOptions.SectionName));

            services.AddAppAutoMapper();
            services.AddAppJwtAuth();

            services.AddControllers();
            services.AddDbContextFactory<MainContext>();
            services.AddMediatR(config => config.RegisterServicesFromAssemblies(Assembly.GetAssembly(typeof(Infrastructure.AssemblyMarker))));

            services.SeedTestData();

            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<ITokenService, TokenService>();

            services.AddValidatorsFromAssembly(Assembly.GetAssembly(typeof(Infrastructure.AssemblyMarker)));
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseAppAuth();
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