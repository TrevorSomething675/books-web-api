using BooksApi.Core.OptionModels;

namespace BooksApi.Web.Configurations
{
    public static class ServiceCollectionDataBaseExtensions
    {
        public static void AddAppAoptionsConfiguration(this IServiceCollection services)
        {
            var configuration = services.BuildServiceProvider().GetService<IConfiguration>();
            services.Configure<DataBaseOptions>(configuration.GetSection(DataBaseOptions.SectionName));
        }
    }
}