namespace BooksApi.Core.Shared
{
    public class BookResponse(int id) : IResponse
    {
        public int Id { get; } = id;
    }
}
