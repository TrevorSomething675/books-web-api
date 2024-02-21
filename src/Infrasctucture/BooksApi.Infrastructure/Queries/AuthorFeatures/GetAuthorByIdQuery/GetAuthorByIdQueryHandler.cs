using BooksApi.Application.Repositories;
using BooksApi.Core.Shared;
using FluentValidation;
using Ardalis.Result;
using MediatR;
using Ardalis.Result.FluentValidation;
using AutoMapper;

namespace BooksApi.Infrastructure.Queries.AuthorFeatures.GetAuthorByIdQuery
{
    public class GetAuthorByIdQueryHandler(
        IMapper mapper,
        IAuthorRepository authorRepository,
        IValidator<GetAuthorByIdQuery> commandValidator
        ) : IRequestHandler<GetAuthorByIdQuery, Result<AuthorQueryModel>>
    {
        private readonly IMapper _mapper = mapper;
        private readonly IAuthorRepository _authorRepository = authorRepository;
        private readonly IValidator<GetAuthorByIdQuery> _commandValidator = commandValidator;
        public async Task<Result<AuthorQueryModel>> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
        {
            var validationResult = await _commandValidator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return Result<AuthorQueryModel>.Invalid(validationResult.AsErrors());

            var author = await _authorRepository.GetAuthorByIdAsync(request.Id);
            var authorModel = _mapper.Map<AuthorQueryModel>(author);

            return authorModel == null
                ? Result<AuthorQueryModel>.NotFound($"Книги с Id - {request.Id} не существует")
                : Result<AuthorQueryModel>.Success(authorModel);
        }
    }
}