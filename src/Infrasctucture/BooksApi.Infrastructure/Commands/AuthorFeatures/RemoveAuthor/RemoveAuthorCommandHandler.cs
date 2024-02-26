using Ardalis.Result.FluentValidation;
using BooksApi.Core.Shared;
using FluentValidation;
using Ardalis.Result;
using MediatR;
using BooksApi.DataBase.Repositories.Abstractions;

namespace BooksApi.Infrastructure.Commands.AuthorFeatures.RemoveAuthor
{
    public sealed class RemoveAuthorCommandHandler(
        IAuthorRepository authorRepository,
        IValidator<RemoveAuthorCommand> commandValidator)
        : IRequestHandler<RemoveAuthorCommand, Result<AuthorResponse>>
    {
        private readonly IAuthorRepository _authorRepository = authorRepository;
        private readonly IValidator<RemoveAuthorCommand> _commandValidator = commandValidator;

        public async Task<Result<AuthorResponse>> Handle(RemoveAuthorCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _commandValidator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return Result<AuthorResponse>.Invalid(validationResult.AsErrors());

            var removedAuthorId = await _authorRepository.RemoveAuthorAsync(request.Id);
            return Result<AuthorResponse>.Success(
                new AuthorResponse(removedAuthorId), "Автор был успешно удалён");
        }
    }
}