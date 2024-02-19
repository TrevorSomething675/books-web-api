using FluentValidation;

namespace BooksApi.Infrastructure.Commands.AuthorFeatures.CreateAuthor
{
    public class CreateAuthorCommandValidator : AbstractValidator<CreateAuthorCommand>
    {
        public CreateAuthorCommandValidator()
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(command => command.Name)
                .NotNull().NotEmpty()
                .Length(8, 24);
        }
    }
}