using BooksApi.Core.Shared;
using FluentValidation;

namespace BooksApi.Infrastructure.Commands.AuthorFeatures.UpdateAuthor
{
    public class UpdateAuthorCommandValidator : AbstractValidator<UpdateAuthorCommand>
    {
        public UpdateAuthorCommandValidator()
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(command => command.Author)
                .NotNull().NotEmpty();

            RuleFor(command => command.Author.Id)
                .NotNull().NotEmpty()
                .Must(CheckField.IsNumber).WithMessage("Id должен быть числом");

            RuleFor(command => command.Author.Name)
                .NotNull().NotEmpty();
        }
    }
}