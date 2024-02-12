using BooksApi.Core.WebModels.Author;
using FluentValidation;

namespace BooksApi.Infrastructure.Validators.AuthorValidators.CreateAuthorCommandValidator
{
    public class RequestAuthorCommandValidator : AbstractValidator<AuthorRequest>
    {
        public RequestAuthorCommandValidator() 
        {
            RuleFor(author => author.Name)
                .Length(8, 24).WithMessage("Имя должно быть больше 8, но меньше 24 символов")
                .NotNull().WithMessage("Id не должен быть пустым");

            RuleFor(author => author.Id)
                .NotNull().WithMessage("Id не должен быть пустым");
        }
    }
}