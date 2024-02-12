using BooksApi.Infrastructure.AuthorFeatures.Commands;
using FluentValidation;

namespace BooksApi.Infrastructure.Validators.AuthorValidators.RemoveAuthorCommandValidator
{
    public class RemoveAuthorCommandValidator : AbstractValidator<RemoveAuthorCommand>
    {
        public RemoveAuthorCommandValidator() 
        {
            RuleFor(command => command.Id)
                .NotNull();
        }
    }
}