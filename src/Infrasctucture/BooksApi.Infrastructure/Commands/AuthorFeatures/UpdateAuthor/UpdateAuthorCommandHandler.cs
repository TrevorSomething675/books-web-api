using BooksApi.Application.Repositories;
using Ardalis.Result.FluentValidation;
using BooksApi.Core.Shared;
using FluentValidation;
using Ardalis.Result;
using MediatR;

namespace BooksApi.Infrastructure.Commands.AuthorFeatures.UpdateAuthor
{
    public sealed class UpdateAuthorCommandHandler(
        IAuthorRepository authorRepository,
        IValidator<UpdateAuthorCommand> commandValidator
        )
        : IRequestHandler<UpdateAuthorCommand, Result<AuthorResponse>>
    {
        private readonly IAuthorRepository _authorRepository = authorRepository;
        private readonly IValidator<UpdateAuthorCommand> _commandValidator = commandValidator;

        public async Task<Result<AuthorResponse>> Handle(UpdateAuthorCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _commandValidator.ValidateAsync(command, cancellationToken);
            if (!validationResult.IsValid)
                return Result<AuthorResponse>.Invalid(validationResult.AsErrors());

            var updatedAuthorId = await _authorRepository.UpdateAuthorAsync(command.Author);
            return Result<AuthorResponse>.Success(
                new AuthorResponse(updatedAuthorId), "Автор был успешно редактирован");
        }
    }
}