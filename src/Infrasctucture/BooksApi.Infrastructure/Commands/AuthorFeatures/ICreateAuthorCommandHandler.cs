using BooksApi.Application.Abstractions;

namespace BooksApi.Infrastructure.Commands.AuthorFeatures
{
    public interface ICreateAuthorCommandHandler
    {
        Task<Result<CreatedAuthorResponse>> Handle(CreateAuthorCommand command, CancellationToken cancellationToken);
    }
}