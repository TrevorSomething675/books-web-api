using BooksApi.Infrastructure.Commands.AuthorFeatures.CreateAuthor;
using BooksApi.Infrastructure.Commands.AuthorFeatures.UpdateAuthor;
using BooksApi.Infrastructure.Commands.AuthorFeatures.RemoveAuthor;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using MediatR;

namespace BooksApi.Web.Controllers
{
    public class AuthorController(
            IMediator mediator
            ) : Controller
    {
        private readonly IMediator _mediator = mediator;

        [HttpGet]
        public async Task<IResult> GetAuthorById([Required] int id)
        {
            return Results.Ok();
        }
        [HttpGet]
        public async Task<IResult> GetAuthors()
        {
            return Results.Ok("author");
        }
        [HttpPost]
        public async Task<IResult> CreateAuthor([Required][FromBody] CreateAuthorCommand command)
        {
            var result = await _mediator.Send(command);
            return Results.Ok(result);
        }
        [HttpPut]
        public async Task<IResult> UpdateAuthor([Required] UpdateAuthorCommand command)
        {
            var result = await _mediator.Send(command);
            return Results.Ok(result);
        }
        [HttpDelete]
        public async Task<IResult> RemoveAuthor([Required] RemoveAuthorCommand command)
        {
            var result = await _mediator.Send(command);
            return Results.Ok(result);
        }
    }
}