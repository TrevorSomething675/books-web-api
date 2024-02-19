using BooksApi.Application.Repositories;
using Ardalis.Result.FluentValidation;
using BooksApi.Domain.Entities;
using BooksApi.Core.Shared;
using FluentValidation;
using Ardalis.Result;
using AutoMapper;
using MediatR;

namespace BooksApi.Infrastructure.Commands.AuthorFeatures.UpdateAuthor
{
    public sealed class UpdateAuthorCommandHandler(
        IMapper mapper,
        IAuthorRepository authorRepository,
        IValidator<UpdateAuthorCommand> commandValidator
        )
        : IRequestHandler<UpdateAuthorCommand, Result<AuthorResponse>>
    {
        private readonly IMapper _mapper = mapper;
        private readonly IAuthorRepository _authorRepository = authorRepository;
        private readonly IValidator<UpdateAuthorCommand> _commandValidator = commandValidator;

        public async Task<Result<AuthorResponse>> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _commandValidator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return Result<AuthorResponse>.Invalid(validationResult.AsErrors());

            var author = _mapper.Map<Author>(request);
            var updatedAuthorId = await _authorRepository.UpdateAuthorAsync(author);
            return Result<AuthorResponse>.Success(
                new AuthorResponse(updatedAuthorId), "Автор был успешно редактирован");
        }
    }
}