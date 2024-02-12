using BooksApi.Infrastructure.AuthorFeatures.Responses;
using BooksApi.Core.WebModels.Author;
using Ardalis.Result;
using MediatR;

namespace BooksApi.Infrastructure.AuthorFeatures.Commands
{
    public class UpdateAuthorCommand : IRequest<Result<UpdatedAuthorReponse>>
    {
        public AuthorRequest? Author { get; set; }
    }
}