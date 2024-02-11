using BooksApi.Core.WebModels.Author;

namespace BooksApi.Core.WebModels.Book
{
    public class BookRequest
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public int PageCount { get; set; }
        public int AuthorId { get; set; }
        public AuthorRequest Author { get; set; }
    }
}