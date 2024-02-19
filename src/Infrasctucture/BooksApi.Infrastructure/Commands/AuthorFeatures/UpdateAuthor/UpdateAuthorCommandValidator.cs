using BooksApi.Core.Shared;
using FluentValidation;

namespace BooksApi.Infrastructure.Commands.AuthorFeatures.UpdateAuthor
{
    public class UpdateAuthorCommandValidator : AbstractValidator<UpdateAuthorCommand>
    {
        public UpdateAuthorCommandValidator()
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(command => command.Id)
                .NotNull().NotEmpty()
                .Must(CheckField.IsNumber).WithMessage("Id должен быть числом");

            RuleFor(command => command.Name)
                .NotNull().NotEmpty();
        }
    }
}