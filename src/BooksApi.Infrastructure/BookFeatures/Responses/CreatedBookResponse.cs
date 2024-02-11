using BooksApi.Core.Shared;

namespace BooksApi.Infrastructure.BookFeatures.Responses
{
    public class CreatedBookResponse(int? id) : IResponse
    {
        public int? Id = id;
    }
}