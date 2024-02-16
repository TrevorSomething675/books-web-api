using BooksApi.Core.Shared;
using FluentValidation;

namespace BooksApi.Infrastructure.Commands.BookFeature.CreateBook
{
    public class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
    {
        public CreateBookCommandValidator()
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(command => command.Book)
                .NotNull().NotEmpty();

            RuleFor(command => command.AuthorName)
                .NotNull().NotEmpty();

            When(command => command.Book != null && command.AuthorName != null, () =>
            {
                RuleFor(command => command.Book.Id)
                    .NotNull().NotEmpty()
                    .Must(CheckField.IsNumber).WithMessage("Id должен быть числом");

                RuleFor(command => command.Book.Name)
                    .NotNull().NotEmpty()
                    .Length(4, 24);

                RuleFor(command => command.Book.PagesCount)
                    .NotNull().NotEmpty()
                    .Must(CheckField.IsNumber).WithMessage("Количество страниц должно быть числом");

                RuleFor(command => command.Book.AuthorId)
                    .NotNull().NotEmpty()
                    .Must(CheckField.IsNumber).WithMessage("Id должен быть числом");
            });
        }
    }
}