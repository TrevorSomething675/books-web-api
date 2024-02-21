using BooksApi.Core.Shared;
using Ardalis.Result;
using MediatR;

namespace BooksApi.Infrastructure.Queries.BookFeatures.GetBookByIdQuery
{
    public class GetBookByIdQuery(int id) : IRequest<Result<BookQueryModel>>
    {
        public int Id { get; } = id;
    }
}