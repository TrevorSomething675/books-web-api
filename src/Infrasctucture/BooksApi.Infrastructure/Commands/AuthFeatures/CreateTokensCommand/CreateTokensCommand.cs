using BooksApi.Core.Shared;
using Ardalis.Result;
using MediatR;

namespace BooksApi.Infrastructure.Commands.AuthFeatures.CreateTokensCommand
{
    public class CreateTokensCommand : IRequest<Result<AuthWithTokensModel>>
    {
        public string Role { get; set; }
    }
}