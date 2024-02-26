using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using BooksApi.Application.Services;
using Microsoft.Extensions.Options;
using BooksApi.Core.OptionModels;
using System.Security.Claims;
using BooksApi.Core.Shared;
using System.Text;

namespace BooksApi.Infrastructure.Services
{
    public class TokenService(
        IOptions<JwtAuthOptions> options
        ) : ITokenService
    {
        private readonly JwtAuthOptions _options = options.Value;
        public async Task<AuthWithTokensModel> GetTokens(string Role)
        {
            var tokens = new AuthWithTokensModel
            {
                AccessToken = await CreateAccessToken(Role),
                RefreshToken = await CreateRefreshToken(Role)
            };
            return tokens;
        }
        public async Task<AuthWithTokensModel> GetTokensOnRefreshToken(string refreshToken)
        {
            var handler = new JwtSecurityTokenHandler();
            var jwtRefreshToken = handler.ReadJwtToken(refreshToken);
            var role = handler.ReadJwtToken(refreshToken).Claims.FirstOrDefault(t => t.Value == "Role").Value;

            var tokens = new AuthWithTokensModel
            {
                AccessToken = await CreateAccessToken(role),
                RefreshToken = await CreateRefreshToken(role)
            };
            return tokens;
        }
        private async Task<string> CreateAccessToken(string Role)
        {
            var claims = new List<Claim> {
                new Claim(ClaimTypes.Role, Role),
                };
            var jwt = new JwtSecurityToken(
                issuer: _options.Issuer,
                audience: _options.Audience,
                claims: claims,
                expires: DateTime.UtcNow.Add(TimeSpan.FromDays(_options.ExpAccessTokenInDays)),
                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(_options.Key)),
                    SecurityAlgorithms.HmacSha256)
                );

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }
        private async Task<string> CreateRefreshToken(string Role)
        {
            var claims = new List<Claim> {
                new Claim(ClaimTypes.Role, Role),
                };
            var jwt = new JwtSecurityToken(
                issuer: _options.Issuer,
                audience: _options.Audience,
                claims: claims,
                expires: DateTime.UtcNow.Add(TimeSpan.FromDays(_options.ExpRefreshTokenInDays)),
                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(_options.Key)),
                    SecurityAlgorithms.HmacSha256)
                );

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }
    }
}