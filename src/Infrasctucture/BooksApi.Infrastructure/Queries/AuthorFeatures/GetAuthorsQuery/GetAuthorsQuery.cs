using BooksApi.Core.Shared;
using Ardalis.Result;
using MediatR;


namespace BooksApi.Infrastructure.Queries.AuthorFeatures.GetAuthorsQuery
{
    public class GetAuthorsQuery(int pageNumber) : IRequest<Result<List<AuthorQueryModel>>>
    {
        public int PageNumber { get; } = pageNumber;
    }
}