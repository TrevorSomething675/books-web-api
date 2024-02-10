namespace BooksApi.Core.WebModels
{
    public class AuthorRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<BookRequest> Books { get; set; }
    }
}