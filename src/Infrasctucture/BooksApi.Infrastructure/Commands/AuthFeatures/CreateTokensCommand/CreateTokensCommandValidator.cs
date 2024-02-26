using FluentValidation;

namespace BooksApi.Infrastructure.Commands.AuthFeatures.CreateTokensCommand
{
    public class CreateTokensCommandValidator : AbstractValidator<CreateTokensCommand>
    {
        public CreateTokensCommandValidator() 
        {
            RuleFor(command => command.Role)
                .NotEmpty().NotNull();
        }
    }
}