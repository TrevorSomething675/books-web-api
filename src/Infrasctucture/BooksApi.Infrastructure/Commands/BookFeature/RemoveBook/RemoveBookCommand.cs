using BooksApi.Core.Shared;
using Ardalis.Result;
using MediatR;

namespace BooksApi.Infrastructure.Commands.BookFeature.RemoveBook
{
    public class RemoveBookCommand(int id) : IRequest<Result<BookResponse>>
    {
        public int Id { get; } = id;
    }
}