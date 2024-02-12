using BooksApi.Core.WebModels.Book;
using FluentValidation;

namespace BooksApi.Infrastructure.Validators.BookValidators.CreateBookCommandValidator
{
    public class CreateBookCommandValidator : AbstractValidator<BookRequest>
    {
        public CreateBookCommandValidator()
        {
            RuleFor(book => book.Name)
                .Length(8, 24).WithMessage("Название книги должны быть больше 6 букв")
                .NotNull().WithMessage("Низвание книги не должно быть пустым");

            RuleFor(book => book.PageCount)
                .NotNull().WithMessage("Количество страниц не может быть пустым");
        }
    }
}