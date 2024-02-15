using FluentValidation;

namespace BooksApi.Infrastructure.Commands.AuthorFeatures.CreateAuthor
{
    public class CreateAuthorCommandValidator : AbstractValidator<CreateAuthorCommand>
    {
        public CreateAuthorCommandValidator()
        {
        }
    }
}
