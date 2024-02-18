namespace BooksApi.Core.Shared
{
    public class AuthorQueryModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<BookQueryModel> Books { get; set; }
    }
}
