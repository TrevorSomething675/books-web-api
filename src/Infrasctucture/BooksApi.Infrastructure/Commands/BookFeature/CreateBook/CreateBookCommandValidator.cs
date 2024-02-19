using BooksApi.Core.Shared;
using FluentValidation;

namespace BooksApi.Infrastructure.Commands.BookFeature.CreateBook
{
    public class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
    {
        public CreateBookCommandValidator()
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(command => command.Name)
                .NotNull().NotEmpty()
                .Length(4, 24);

            RuleFor(command => command.PagesCount)
                .NotNull().NotEmpty()
                .Must(CheckField.IsNumber).WithMessage("Количество страниц должно быть числом");

            RuleFor(command => command.AuthorId)
                .NotNull().NotEmpty()
                .Must(CheckField.IsNumber).WithMessage("Id автора должен быть числом");
        }
    }
}