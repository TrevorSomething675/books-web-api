using Ardalis.Result;
using BooksApi.Infrastructure.AuthorFeatures.Responses;
using MediatR;

namespace BooksApi.Infrastructure.AuthorFeatures.Commands
{
    public class RemoveAuthorCommand : IRequest<Result<RemovedAuthorResponse>>
    {
        public int Id { get; set; }
    }
}