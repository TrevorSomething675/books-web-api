using BooksApi.Infrastructure.Queries.AuthorFeatures.GetBookByIdQuery;
using BooksApi.Infrastructure.Commands.BookFeature.CreateBook;
using System.ComponentModel.DataAnnotations;
using Ardalis.Result.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using BooksApi.Web.Extensions;
using MediatR;

namespace BooksApi.Web.Controllers
{
    public class BookController(
        IMediator mediator
        ) : Controller
    {
        private readonly IMediator _mediator = mediator;

        [HttpGet]
        public async Task<IActionResult> GetBookById([Required] int id)
        {
            return (await _mediator.Send(new GetBookByIdQuery(id))).ToActionResult();
        }
        [HttpGet]
        public async Task<IResult> GetBooks()
        {
            return Results.Ok("book");
        }
        [HttpPost]
        public async Task<IActionResult> CreateBook([Required] CreateBookCommand command)
        {
            return (await _mediator.Send(command)).ToActionResult();
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