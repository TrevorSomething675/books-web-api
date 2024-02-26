namespace BooksApi.DataBase.Entities
{
    public class AuthorEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<BookEntity> Books { get; set; }
    }
}