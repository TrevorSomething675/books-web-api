namespace BooksApi.Core.Shared
{
    public class AuthorResponse(int id) : IResponse
    {
        public int Id { get; } = id;
    }
}
