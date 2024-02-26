using BooksApi.Core.Shared;
using Ardalis.Result;
using MediatR;

namespace BooksApi.Infrastructure.Commands.BookFeatures.RemoveBook
{
    public class RemoveBookCommand(int id) : IRequest<Result<BookResponse>>
    {
        public int Id { get; } = id;
    }
}