using BooksApi.Core.WebModels.Book;
using FluentValidation;


namespace BooksApi.Infrastructure.Validators.BookValidators
{
    public class RequestBookValidator : AbstractValidator<BookRequest>
    {
        public RequestBookValidator()
        {
            RuleFor(book => book.Name)
                .NotNull();
        }
    }
}