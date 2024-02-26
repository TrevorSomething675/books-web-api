using FluentValidation;

namespace BooksApi.Infrastructure.Commands.BookFeatures.UpdateBook
{
    public class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommand>
    {
        public UpdateBookCommandValidator() 
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(command => command.Name)
                .NotNull().NotEmpty()
                .Length(8, 14);
        }
    }
}