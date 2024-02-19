using BooksApi.Application.Repositories;
using Ardalis.Result.FluentValidation;
using BooksApi.Domain.Entities;
using BooksApi.Core.Shared;
using FluentValidation;
using Ardalis.Result;
using AutoMapper;
using MediatR;

namespace BooksApi.Infrastructure.Commands.AuthorFeatures.CreateAuthor
{
    public sealed class CreateAuthorCommandHandler(
        IMapper mapper,
        IAuthorRepository authorRepository,
        IValidator<CreateAuthorCommand> commandValidator
        )
        : IRequestHandler<CreateAuthorCommand, Result<AuthorResponse>>
    {
        private readonly IMapper _mapper = mapper;
        private readonly IAuthorRepository _authorRepository = authorRepository;
        private readonly IValidator<CreateAuthorCommand> _commandValidator = commandValidator;

        public async Task<Result<AuthorResponse>> Handle(CreateAuthorCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _commandValidator.ValidateAsync(command, cancellationToken);
            if (!validationResult.IsValid)
                return Result<AuthorResponse>.Invalid(validationResult.AsErrors());

            var author = _mapper.Map<Author>(command);
            var createdAuthorId = await _authorRepository.CreateAuthorAsync(author);
            return Result<AuthorResponse>.Success(
                new AuthorResponse(createdAuthorId), "Автор был успешно добавлен");
        }
    }
}