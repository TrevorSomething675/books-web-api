﻿using BooksApi.Infrastructure.Commands.AuthorFeatures.CreateAuthor;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using BooksApi.Infrastructure.Commands.AuthorFeatures.UpdateAuthor;

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
        public async Task<IResult> CreateAuthor([Required] CreateAuthorCommand command)
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
        public async Task<IResult> RemoveAuthor([Required] int id)
        {
            return Results.Ok();
        }
    }
}