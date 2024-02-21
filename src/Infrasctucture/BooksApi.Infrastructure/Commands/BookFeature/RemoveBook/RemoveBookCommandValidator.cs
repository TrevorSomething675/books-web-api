using BooksApi.Core.Shared;
using FluentValidation;

namespace BooksApi.Infrastructure.Commands.BookFeature.RemoveBook
{
    public class RemoveBookCommandValidator : AbstractValidator<RemoveBookCommand>
    {
        public RemoveBookCommandValidator() 
        {
            RuleFor(command => command.Id)
                .NotNull().NotEmpty().
                Must(CheckField.IsNumber).WithMessage("Id автора должен быть числом");
        }
    }
}