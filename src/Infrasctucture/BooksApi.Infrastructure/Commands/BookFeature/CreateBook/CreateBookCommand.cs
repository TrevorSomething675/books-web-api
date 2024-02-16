using BooksApi.Domain.Entities;
using BooksApi.Core.Shared;
using Ardalis.Result;
using MediatR;

namespace BooksApi.Infrastructure.Commands.BookFeature.CreateBook
{
    public class CreateBookCommand : IRequest<Result<BookResponse>>
    {
        public string AuthorName { get; set; }
        public Book Book { get; set; }
    }
}