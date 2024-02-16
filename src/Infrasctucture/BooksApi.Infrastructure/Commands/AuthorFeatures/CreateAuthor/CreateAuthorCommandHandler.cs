using BooksApi.Application.Repositories;
using Ardalis.Result.FluentValidation;
using BooksApi.Core.Shared;
using FluentValidation;
using Ardalis.Result;
using MediatR;

namespace BooksApi.Infrastructure.Commands.AuthorFeatures.CreateAuthor
{
    public sealed class CreateAuthorCommandHandler(
        IAuthorRepository authorRepository,
        IValidator<CreateAuthorCommand> commandValidator
        )
        : IRequestHandler<CreateAuthorCommand, Result<AuthorResponse>>
    {
        private readonly IAuthorRepository _authorRepository = authorRepository;
        private readonly IValidator<CreateAuthorCommand> _commandValidator = commandValidator;

        public async Task<Result<AuthorResponse>> Handle(CreateAuthorCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _commandValidator.ValidateAsync(command, cancellationToken);
            if (!validationResult.IsValid)
                return Result<AuthorResponse>.Invalid(validationResult.AsErrors());

            var createdAuthorId = await _authorRepository.CreateAuthorAsync(command.Author);
            return Result<AuthorResponse>.Success(
                new AuthorResponse(createdAuthorId), "Автор был успешно добавлен");
        }
    }
}