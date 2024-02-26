using BooksApi.Core.Abstractions.Repositories;
using BooksApi.Core.Shared;
using Ardalis.Result;
using AutoMapper;
using MediatR;

namespace BooksApi.Infrastructure.Queries.AuthorFeatures.GetAuthorsQuery
{
    public class GetAuthorsQueryHandler(
        IMapper mapper,
        IAuthorRepository authorRepository
        ) : IRequestHandler<GetAuthorsQuery, Result<List<AuthorQueryModel>>>
    {
        private readonly IMapper _mapper = mapper;
        private readonly IAuthorRepository _authorRepository = authorRepository;

        public async Task<Result<List<AuthorQueryModel>>> Handle(
            GetAuthorsQuery request,
            CancellationToken cancellationToken)
        {
            var authors = await _authorRepository.GetAuthorsAsync(request.PageNumber);
            var authorsResponse = _mapper.Map<List<AuthorQueryModel>>(authors);

            return Result<List<AuthorQueryModel>>.Success(authorsResponse);
        }
    }
}