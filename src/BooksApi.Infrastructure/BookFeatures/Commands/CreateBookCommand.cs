using BooksApi.Infrastructure.BookFeatures.Responses;
using BooksApi.Core.WebModels.Book;
using Ardalis.Result;
using MediatR;

namespace BooksApi.Infrastructure.BookFeatures.Commands
{
    public class CreateBookCommand : IRequest<Result<CreatedBookResponse>>
    {
        public BookRequest? Book { get; set; }
    }
}