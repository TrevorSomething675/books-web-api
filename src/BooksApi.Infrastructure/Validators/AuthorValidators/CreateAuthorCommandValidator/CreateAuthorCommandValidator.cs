using BooksApi.Infrastructure.AuthorFeatures.Commands;
using FluentValidation;

namespace BooksApi.Infrastructure.Validators.AuthorValidators.CreateAuthorCommandValidator
{
    public class CreateAuthorCommandValidator : AbstractValidator<CreateAuthorCommand>
    {
        public CreateAuthorCommandValidator()
        {
            RuleFor(command => command.AuthorRequest)
                .NotNull();
        }
    }
}