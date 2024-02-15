using System.Reflection;
using AutoMapper;

namespace BooksApi.Web.Configurations
{
    public static class ServicesCollectionAutoMapperExtensions
    {
        public static void AddAppAutoMapper(this IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(config =>
            {
                config.AddMaps(Assembly.GetAssembly(typeof(Infrastructure.AssemblyMarker)));
            });
            var mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}