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
        public async Task<Result<AuthorResponse>> Handle(UpdateAuthorCommand command, CancellationToken cancellationToken)
        {
            var validatorResult = await commandValidator.ValidateAsync(command, cancellationToken);
            if (!validatorResult.IsValid)
                return Result<AuthorResponse>.Invalid(validatorResult.AsErrors());

            var updatedAuthorId = await _authorRepository.UpdateAuthorAsync(command.Author);
            return Result<AuthorResponse>.Success(
                new AuthorResponse(updatedAuthorId), "Success operation.");
        }
    }
}