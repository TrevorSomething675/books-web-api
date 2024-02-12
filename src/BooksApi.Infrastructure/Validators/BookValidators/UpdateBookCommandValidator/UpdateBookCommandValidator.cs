using BooksApi.Infrastructure.AuthorFeatures.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksApi.Infrastructure.Validators.BookValidators.UpdateBookCommandValidator
{
    public class UpdateBookCommandValidator : AbstractValidator<RemoveAuthorCommand>
    {
        public UpdateBookCommandValidator() 
        {
            RuleFor(command => command.Id);
        }
    }
}
