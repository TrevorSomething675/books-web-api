using BooksApi.Core.Shared;
using Ardalis.Result;
using MediatR;

namespace BooksApi.Infrastructure.Commands.AuthorFeatures.RemoveAuthor
{
    public class RemoveAuthorCommand
        : IRequest<Result<AuthorResponse>>
    {
        public int Id { get; set; }
    }
}