using BooksApi.Core.Shared;
using Ardalis.Result;
using MediatR;

namespace BooksApi.Infrastructure.Commands.AuthFeatures.CreateTokensOnRefreshCommand
{
    public class GetTokensOnRefreshTokenCommand : IRequest<Result<AuthWithTokensModel>>
    {
        public string Role { get; set; }
        public string RefreshToken { get; set; }
    }
}