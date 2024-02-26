namespace BooksApi.DataBase.Entities
{ 
    public class BookEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PagesCount { get; set; }
        public int AuthorId { get; set; }
        public AuthorEntity Author { get; set; }
    }
}
