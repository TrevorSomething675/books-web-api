using BooksApi.Core.Shared;
using FluentValidation;

namespace BooksApi.Infrastructure.Queries.BookFeatures.GetBookByIdQuery
{
    public class GetBookByIdQueryValidator : AbstractValidator<GetBookByIdQuery>
    {
        public GetBookByIdQueryValidator()
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(query => query.Id)
                .NotEmpty().NotNull()
                .Must(CheckField.IsNumber).WithMessage("Id должен быть числом");
        }
    }
}