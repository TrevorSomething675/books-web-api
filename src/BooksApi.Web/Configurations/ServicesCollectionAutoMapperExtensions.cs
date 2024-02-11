using AutoMapper;
using System.Reflection;

namespace BooksApi.Web.Configurations
{
    public static class ServicesCollectionAutoMapperExtensions
    {
        public static void AddAppAutoMapper(this IServiceCollection services) 
        {
            var mapperConfig = new MapperConfiguration(config =>
            {
                config.AddMaps(Assembly.GetAssembly(typeof(Application.AssemblyMarker)));
            });
            var mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
