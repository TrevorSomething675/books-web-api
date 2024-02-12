using BooksApi.Infrastructure.AuthorFeatures.Responses;
using BooksApi.Infrastructure.AuthorFeatures.Commands;
using BooksApi.Application.Repositories;
using Ardalis.Result.FluentValidation;
using BooksApi.Core.Entities;
using FluentValidation;
using Ardalis.Result;
using AutoMapper;
using MediatR;

namespace BooksApi.Infrastructure.AuthorFeatures.Handlers
{
    public class CreateAuthorCommandHandler(
        IAuthorRepository authorRepository,
        IMapper mapper,
        IValidator<CreateAuthorCommand> validator)
        : IRequestHandler<CreateAuthorCommand, Result<CreatedAuthorResponse>>
    {
        private readonly IAuthorRepository _authorRepository = authorRepository;
        private readonly IMapper _mapper = mapper;
        public async Task<Result<CreatedAuthorResponse>> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await validator.ValidateAsync(request);
            if (!validationResult.IsValid)
                return Result<CreatedAuthorResponse>.Invalid(validationResult.AsErrors());

            var author = _mapper.Map<Author>(request.AuthorRequest);
            var addedAuthorId = await _authorRepository.CreateAuthor(author);

            return Result<CreatedAuthorResponse>.Success(
                new CreatedAuthorResponse(addedAuthorId), "Successfully operation");
        }
    }
}