using BooksApi.Core.Shared;
using Ardalis.Result;
using MediatR;

namespace BooksApi.Infrastructure.Queries.BookFeatures.GetBooksQuery
{
    public class GetBooksQuery(int pageNumber) : IRequest<Result<List<BookQueryModel>>>
    {
        public int PageNumber { get; } = pageNumber;
    }
}