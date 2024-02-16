using FluentValidation;

namespace BooksApi.Infrastructure.Commands.AuthorFeatures.CreateAuthor
{
    public class CreateAuthorCommandValidator : AbstractValidator<CreateAuthorCommand>
    {
        public CreateAuthorCommandValidator()
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(command => command.Author)
                .NotNull().NotEmpty();

            When(command => command.Author != null, () => 
            {
                RuleFor(command => command.Author.Name)
                    .NotNull().NotEmpty()
                    .Length(8, 24);
            });
        }
    }
}