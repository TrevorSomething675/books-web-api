using BooksApi.Core.Shared;
using Ardalis.Result;
using MediatR;

namespace BooksApi.Infrastructure.Queries.AuthorFeatures.GetAuthorByIdQuery
{
    public class GetAuthorByIdQuery(int id) : IRequest<Result<AuthorQueryModel>>
    {
        public int Id { get; } = id;
    }
}