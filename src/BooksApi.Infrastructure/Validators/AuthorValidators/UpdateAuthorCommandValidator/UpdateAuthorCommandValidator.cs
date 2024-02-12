using BooksApi.Infrastructure.AuthorFeatures.Commands;
using FluentValidation;

namespace BooksApi.Infrastructure.Validators.AuthorValidators.UpdateAuthorCommandValidator
{
    public class UpdateAuthorCommandValidator : AbstractValidator<UpdateAuthorCommand>
    {
        public UpdateAuthorCommandValidator() 
        {
            RuleFor(command => command.Author)
                .NotNull();
        }
    }
}