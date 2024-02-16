using BooksApi.Core.Shared;
using FluentValidation;

namespace BooksApi.Infrastructure.Commands.AuthorFeatures.RemoveAuthor
{
    public class RemoveAuthorCommandValidator : AbstractValidator<RemoveAuthorCommand>
    {
        public RemoveAuthorCommandValidator() 
        {
            RuleFor(command => command.Id)
                .Must(CheckField.IsNumber).WithMessage("Id должен быть числом")
                .NotNull().NotEmpty();
        }
    }
}