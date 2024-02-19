using BooksApi.Core.Shared;
using Ardalis.Result;
using MediatR;

namespace BooksApi.Infrastructure.Commands.AuthorFeatures.UpdateAuthor
{
    public sealed class UpdateAuthorCommand 
    : IRequest<Result<AuthorResponse>>
    {
        public int Id { get; set; } //Id автора, которому нужно обновить поля
        public string Name { get; set; }
        public List<int> BooksId { get; set; }
    }
}