namespace BooksApi.Core.Shared
{
    public class BookCommandResponse(int id) : IResponse
    {
        public int Id { get; } = id;
    }
}