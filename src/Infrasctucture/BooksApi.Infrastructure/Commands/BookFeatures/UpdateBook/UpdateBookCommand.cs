using BooksApi.Core.Shared;
using Ardalis.Result;
using MediatR;

namespace BooksApi.Infrastructure.Commands.BookFeatures.UpdateBook
{
    public class UpdateBookCommand : IRequest<Result<BookResponse>>
    {
        public string Name { get; set; }
        public int PagesCount { get; set; }
    }
}