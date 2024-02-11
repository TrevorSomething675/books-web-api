using BooksApi.Core.WebModels.Book;

namespace BooksApi.Core.WebModels.Author
{
    public class AuthorResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<BookResponse> Books { get; set; }
    }
}