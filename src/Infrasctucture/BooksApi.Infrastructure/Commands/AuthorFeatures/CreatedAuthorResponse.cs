using BooksApi.Core.Shared;

namespace BooksApi.Infrastructure.Commands.AuthorFeatures
{
    public class CreatedAuthorResponse(int id) : IResponse
    {
        public int Id { get; } = id;
    }
}