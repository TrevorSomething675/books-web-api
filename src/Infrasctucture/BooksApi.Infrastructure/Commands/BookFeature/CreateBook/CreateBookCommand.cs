using BooksApi.Core.Shared;
using Ardalis.Result;
using MediatR;

namespace BooksApi.Infrastructure.Commands.BookFeature.CreateBook
{
    public class CreateBookCommand : IRequest<Result<BookResponse>>
    {
        public string Name { get; set; }
        public int PagesCount { get; set; }
        public int AuthorId { get; set; }
    }
}