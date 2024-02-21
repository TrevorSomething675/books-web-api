using BooksApi.Infrastructure.Queries.BookFeatures.GetBookByIdQuery;
using BooksApi.Infrastructure.Queries.BookFeatures.GetBooksQuery;
using BooksApi.Infrastructure.Commands.BookFeature.CreateBook;
using BooksApi.Infrastructure.Commands.BookFeature.UpdateBook;
using BooksApi.Infrastructure.Commands.BookFeature.RemoveBook;
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
        public async Task<IActionResult> GetBookById([Required][FromHeader] int id)
        {
            return (await _mediator.Send(new GetBookByIdQuery(id))).ToActionResult();
        }
        [HttpGet]
        public async Task<IActionResult> GetBooks([FromHeader] int pageNumber = 1)
        {
            return (await _mediator.Send(new GetBooksQuery(pageNumber))).ToActionResult();
        }
        [HttpPost]
        public async Task<IActionResult> CreateBook([Required][FromBody] CreateBookCommand command)
        {
            return (await _mediator.Send(command)).ToActionResult();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateBook([Required][FromBody] UpdateBookCommand command)
        {
            return (await _mediator.Send(command)).ToActionResult();
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveBook([Required][FromBody] RemoveBookCommand command)
        {
            return (await _mediator.Send(command)).ToActionResult();
        }
    }
}