using BooksApi.Infrastructure.BookFeatures.Repositories;
using BooksApi.Application.Repositories;
using BooksApi.Infrastructure.Data;
using BooksApi.Web.Configurations;
using System.Reflection;

namespace BooksApi.Web
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAppAoptionsConfiguration();
            services.AddAppAutoMapper();

            services.AddControllers();
            services.AddDbContextFactory<MainContext>();
            services.AddMediatR(config => config.RegisterServicesFromAssemblies(Assembly.GetAssembly(typeof(Infrastructure.AssemblyMarker))));
            services.AddScoped<IBookRepository, BookRepository>();
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
