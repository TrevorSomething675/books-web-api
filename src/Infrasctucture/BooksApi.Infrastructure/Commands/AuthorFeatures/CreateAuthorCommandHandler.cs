using BooksApi.Application.Repositories;
using Ardalis.Result.FluentValidation;
using FluentValidation;
using Ardalis.Result;
using MediatR;

namespace BooksApi.Infrastructure.Commands.AuthorFeatures
{
    public sealed class CreateAuthorCommandHandler(
        IAuthorRepository authorRepository,
        IValidator<CreateAuthorCommand> commandValidator
        )
        : IRequestHandler<CreateAuthorCommand, Result<CreatedAuthorResponse>>
    {
        private readonly IAuthorRepository _authorRepository = authorRepository;
        private readonly IValidator<CreateAuthorCommand> _commandValidator = commandValidator;

        public async Task<Result<CreatedAuthorResponse>> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _commandValidator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return Result<CreatedAuthorResponse>.Invalid(validationResult.AsErrors());

            var createdAuthorId = await _authorRepository.CreateAuthorAsync(request.Author);
            return Result<CreatedAuthorResponse>.Success(
                new CreatedAuthorResponse(createdAuthorId), "Succes operation.");
        }
    }
}