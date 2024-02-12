using BooksApi.Core.Shared;

namespace BooksApi.Infrastructure.AuthorFeatures.Responses
{
    public class CreatedAuthorResponse(int? id) : IResponse
    {
        public int? Id = id;
    }
}
