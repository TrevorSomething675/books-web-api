using BooksApi.Core.Shared;

namespace BooksApi.Core.Abstractions.Services
{
    public interface ITokenService
    {
        public Task<AuthWithTokensModel> GetTokens(string Role);
        public Task<AuthWithTokensModel> GetTokensOnRefreshToken(string refreshToken);
    }
}