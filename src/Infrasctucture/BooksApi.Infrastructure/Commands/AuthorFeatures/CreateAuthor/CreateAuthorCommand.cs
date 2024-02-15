using BooksApi.Domain.Entities;
using BooksApi.Core.Shared;
using Ardalis.Result;
using MediatR;

namespace BooksApi.Infrastructure.Commands.AuthorFeatures.CreateAuthor
{
    public sealed class CreateAuthorCommand
        : IRequest<Result<AuthorResponse>>
    {
        public Author Author { get; set; }
    }
}