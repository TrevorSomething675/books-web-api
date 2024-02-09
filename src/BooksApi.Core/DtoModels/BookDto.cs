namespace BooksApi.Core.DtoModels
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PageCount { get; set; }
        public int AuthorId {get;set;}
        public AuthorDto Author { get; set;}
    }
}