namespace BooksApi.Core.OptionModels
{
    public class DataBaseOptions
    {
        public const string SectionName = "DataBaseSettings";
        public string ConnectionString { get; set; }
    }
}