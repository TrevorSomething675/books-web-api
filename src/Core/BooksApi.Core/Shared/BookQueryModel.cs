using BooksApi.Core.Abstractions;

namespace BooksApi.Core.Shared
{
    public class BookQueryModel : IQueryModel<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PagesCount { get; set; }
        public int AuthorId { get; set; }
        public AuthorQueryModel Author { get; set; }
    }
}