using BooksApi.Infrastructure.Book.Repositories;
using BooksApi.Application.Repositories;
using System.Reflection;

namespace BooksApi.Web
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
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
