using BooksApi.Core.Shared;
using FluentValidation;

namespace BooksApi.Infrastructure.Queries.AuthorFeatures.GetAuthorByIdQuery
{
    public class GetAuthorByIdQueryValidator : AbstractValidator<GetAuthorByIdQuery>
    {
        public GetAuthorByIdQueryValidator()
        {
            RuleFor(query => query.Id)
                .NotNull().NotEmpty()
                .Must(CheckField.IsNumber).WithMessage("Id должен быть числом");
        }
    }
}