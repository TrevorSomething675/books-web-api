using BooksApi.Core.WebModels.Book;

namespace BooksApi.Core.WebModels.Author
{
    public class AuthorRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<BookRequest> Books { get; set; }
    }
}