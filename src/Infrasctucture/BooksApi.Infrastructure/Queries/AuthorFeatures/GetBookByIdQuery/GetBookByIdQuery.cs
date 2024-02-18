using BooksApi.Core.Shared;
using Ardalis.Result;
using MediatR;

namespace BooksApi.Infrastructure.Queries.AuthorFeatures.GetBookByIdQuery
{
    public class GetBookByIdQuery(int id) : IRequest<Result<BookResponse>>
    {
        public int Id { get; } = id;
    }
}