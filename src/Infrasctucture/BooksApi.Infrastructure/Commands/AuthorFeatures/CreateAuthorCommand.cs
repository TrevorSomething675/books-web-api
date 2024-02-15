using BooksApi.Domain.Entities;
using Ardalis.Result;
using MediatR;

namespace BooksApi.Infrastructure.Commands.AuthorFeatures
{
    public class CreateAuthorCommand
        : IRequest<Result<CreatedAuthorResponse>>
    {
        public Author Author { get; set; }
    }
}