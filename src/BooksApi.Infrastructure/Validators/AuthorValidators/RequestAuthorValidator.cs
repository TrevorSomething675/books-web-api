using BooksApi.Core.WebModels.Author;
using FluentValidation;

namespace BooksApi.Infrastructure.Validators.AuthorValidators
{
    public class RequestAuthorValidator : AbstractValidator<AuthorRequest>
    {
        public RequestAuthorValidator()
        {
            RuleFor(author => author.Name)
                .NotNull();
        }
    }
}