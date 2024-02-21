using BooksApi.Infrastructure.Queries.AuthorFeatures.GetAuthorByIdQuery;
using BooksApi.Infrastructure.Queries.AuthorFeatures.GetAuthorsQuery;
using BooksApi.Infrastructure.Commands.AuthorFeatures.CreateAuthor;
using BooksApi.Infrastructure.Commands.AuthorFeatures.UpdateAuthor;
using BooksApi.Infrastructure.Commands.AuthorFeatures.RemoveAuthor;
using System.ComponentModel.DataAnnotations;
using Ardalis.Result.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using BooksApi.Web.Extensions;
using MediatR;

namespace BooksApi.Web.Controllers
{
    public class AuthorController(
            IMediator mediator
            ) : Controller
    {
        private readonly IMediator _mediator = mediator;

        [HttpGet]
        public async Task<IActionResult> GetAuthorById([Required][FromHeader] int id)
        {
            return (await _mediator.Send(new GetAuthorByIdQuery(id))).ToActionResult();
        }
        [HttpGet]
        public async Task<IActionResult> GetAuthors([FromBody][FromHeader] int pageNumber = 1)
        {
            return (await _mediator.Send(new GetAuthorsQuery(pageNumber))).ToActionResult();
        }
        [HttpPost]
        public async Task<IActionResult> CreateAuthor([Required][FromBody] CreateAuthorCommand command)
        {
            return (await _mediator.Send(command)).ToActionResult();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAuthor([Required][FromBody] UpdateAuthorCommand command)
        {
            return (await _mediator.Send(command)).ToActionResult();
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveAuthor([Required][FromBody] RemoveAuthorCommand command)
        {
            return (await _mediator.Send(command)).ToActionResult();
        }
    }
}