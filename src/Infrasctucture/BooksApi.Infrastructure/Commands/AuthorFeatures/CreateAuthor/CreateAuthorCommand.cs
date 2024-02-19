using BooksApi.Core.Shared;
using Ardalis.Result;
using MediatR;

namespace BooksApi.Infrastructure.Commands.AuthorFeatures.CreateAuthor
{
    public sealed class CreateAuthorCommand
        : IRequest<Result<AuthorResponse>>
    {
        public string Name { get; set; }
    }
}