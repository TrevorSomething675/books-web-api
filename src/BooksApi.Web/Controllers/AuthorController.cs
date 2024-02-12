using Microsoft.AspNetCore.Mvc;
using MediatR;
using BooksApi.Infrastructure.AuthorFeatures.Commands;

namespace BooksApi.Web.Controllers
{
    public class AuthorController(
        IMediator mediator
        ) : Controller
    {
        private readonly IMediator _mediator = mediator;
        [HttpGet]
        public async Task<IResult> GetAuthors()
        {
            return Results.Ok("author");
        }
        [HttpPost]
        public async Task<IResult> CreateAuthor(CreateAuthorCommand command)
        {
            var result = await _mediator.Send(command);
            return Results.Ok(result);
        }
        
    }
}