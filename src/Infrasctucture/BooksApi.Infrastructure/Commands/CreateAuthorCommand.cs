using BooksApi.Application.Messaging;
using BooksApi.Domain.Entities;

namespace BooksApi.Infrastructure.Commands
{
    public sealed class CreateAuthorCommand(Author author)
        : ICommand
    {
        
    }

    public sealed class CreateAuthorCommandHandler() : ICommandHandler<CreateAuthorCommand>
    {

    }
}
