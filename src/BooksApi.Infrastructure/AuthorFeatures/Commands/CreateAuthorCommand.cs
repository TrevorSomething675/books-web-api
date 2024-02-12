using BooksApi.Infrastructure.AuthorFeatures.Responses;
using BooksApi.Core.WebModels.Author;
using Ardalis.Result;
using MediatR;

namespace BooksApi.Infrastructure.AuthorFeatures.Commands
{
    public class CreateAuthorCommand : IRequest<Result<CreatedAuthorResponse>>
    {
        public AuthorRequest? AuthorRequest { get; set; }
    }
}