using BooksApi.Core.Shared;

namespace BooksApi.Infrastructure.AuthorFeatures.Responses
{
    public class RemovedAuthorResponse(int? id) : IResponse
    {
        public int? Id = id;
    }
}