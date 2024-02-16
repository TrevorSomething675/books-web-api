using BooksApi.Domain.Entities;
using BooksApi.Core.Shared;
using Ardalis.Result;
using MediatR;

namespace BooksApi.Infrastructure.Commands.AuthorFeatures.UpdateAuthor
{
    /// <summary>
    /// Author.Id это Id пользователя в бд
    /// Всё остальное будет обновлено
    /// </summary>
    public sealed class UpdateAuthorCommand 
    : IRequest<Result<AuthorResponse>>
    {
        public Author Author { get; set; }
    }
}