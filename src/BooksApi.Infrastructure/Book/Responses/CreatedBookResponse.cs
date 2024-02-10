using BooksApi.Core.Shared;

namespace BooksApi.Infrastructure.Book.Responses
{
    public class CreatedBookResponse(int? id) : IResponse
    {
        public int? Id = id;
    }
}