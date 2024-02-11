using BooksApi.Core.WebModels.Author;

namespace BooksApi.Core.WebModels.Book
{
    public class BookResponse
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public int PageCount { get; set; }
        public int AuthorId { get; set; }
        public AuthorResponse Author { get; set; }
    }
}