using BooksApi.Infrastructure.Commands.AuthFeatures.CreateTokensOnRefreshCommand;
using BooksApi.Infrastructure.Commands.AuthFeatures.CreateTokensCommand;
using System.ComponentModel.DataAnnotations;
using Ardalis.Result.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using BooksApi.Web.Extensions;
using MediatR;

namespace BooksApi.Web.Controllers
{
    public class AuthController(
        IMediator mediator
        ) : Controller
    {
        private readonly IMediator _mediator = mediator;

        [HttpGet]
        public async Task<IActionResult> GetTokens([Required][FromHeader] CreateTokensCommand command)
        {
            return (await _mediator.Send(command)).ToActionResult();
        }
        [HttpGet]
        public async Task<IActionResult> GetTokensOnRefreshToken([Required][FromHeader] GetTokensOnRefreshTokenCommand command)
        {
            return (await _mediator.Send(command)).ToActionResult();
        }
    }
}