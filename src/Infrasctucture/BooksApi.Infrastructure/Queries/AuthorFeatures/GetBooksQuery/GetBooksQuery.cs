using BooksApi.Core.Shared;
using Ardalis.Result;
using MediatR;

namespace BooksApi.Infrastructure.Queries.AuthorFeatures.GetBooksQuery
{
    public class GetBooksQuery(uint pageNumber) : IRequest<Result<List<BookQueryModel>>>
    {
        public uint PageNumber { get; } = pageNumber;
    }
}