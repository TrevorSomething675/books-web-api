using BooksApi.Infrastructure.Book.Responses;
using BooksApi.Core.WebModels;
using Ardalis.Result;
using MediatR;

namespace BooksApi.Infrastructure.Book.Commands
{
    public class CreateBookCommand : IRequest<Result<CreatedBookResponse>>
    {
        public BookRequest? Book { get; set; }
    }
}