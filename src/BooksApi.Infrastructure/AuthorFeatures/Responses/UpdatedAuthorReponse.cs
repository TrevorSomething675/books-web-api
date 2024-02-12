using BooksApi.Core.Shared;

namespace BooksApi.Infrastructure.AuthorFeatures.Responses
{
    public class UpdatedAuthorReponse(int? id) : IResponse
    {
        public int? Id = id;
    }
}