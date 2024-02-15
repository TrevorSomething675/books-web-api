using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using BooksApi.Infrastructure.Commands.BookFeature;

namespace BooksApi.Web.Controllers
{
    public class BookController(
        IMediator mediator
        ) : Controller
    {
        private readonly IMediator _mediator = mediator;

        [HttpGet]
        public async Task<IResult> GetBookById([Required] int id)
        {
            return Results.Ok();
        }
        [HttpGet]
        public async Task<IResult> GetBooks()
        {
            return Results.Ok("book");
        }
        [HttpPost]
        public async Task<IResult> CreateBook([Required] CreateBookCommand command)
        {
            var result = await _mediator.Send(command);
            return Results.Ok(result);
        }
        [HttpPut]
        public async Task<IResult> UpdateBook()
        {
            return Results.Ok();
        }
        [HttpDelete]
        public async Task<IResult> RemoveBook()
        {
            return Results.Ok();
        }
    }
}