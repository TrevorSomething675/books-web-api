using BooksApi.Infrastructure.Book.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BooksApi.Web.Controllers
{
    public class BookController(
        IMediator mediator
        ) : Controller
    {
        private readonly IMediator _mediator = mediator;

        public async Task<IResult> GetBooks()
        {
            return Results.Ok("book");
        }
        public async Task<IResult> CreateBook(CreateBookCommand command)
        {
            var result = await _mediator.Send(command);
            return Results.Ok(result);
        }
    }
}