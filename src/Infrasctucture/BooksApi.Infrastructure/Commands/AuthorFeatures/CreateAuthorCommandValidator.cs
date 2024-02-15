using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksApi.Infrastructure.Commands.AuthorFeatures
{
    public class CreateAuthorCommandValidator : AbstractValidator<CreateAuthorCommand>
    {
        public CreateAuthorCommandValidator() 
        {
        }
    }
}
