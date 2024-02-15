using FluentValidation;

namespace BooksApi.Infrastructure.Commands.AuthorFeatures.UpdateAuthor
{
    public class UpdateAuthorCommandValidator : AbstractValidator<UpdateAuthorCommand>
    {
        public UpdateAuthorCommandValidator() 
        {
            
        }
    }
}
