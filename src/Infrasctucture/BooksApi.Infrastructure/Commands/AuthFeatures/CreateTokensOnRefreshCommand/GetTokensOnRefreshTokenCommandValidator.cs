using FluentValidation;

namespace BooksApi.Infrastructure.Commands.AuthFeatures.CreateTokensOnRefreshCommand
{
    public class GetTokensOnRefreshTokenCommandValidator : AbstractValidator<GetTokensOnRefreshTokenCommand>
    {
        public GetTokensOnRefreshTokenCommandValidator()
        {
            RuleFor(command => command.RefreshToken)
                .NotNull().NotEmpty();

            RuleFor(command => command.Role)
                .NotNull().NotEmpty();
        }
    }
}