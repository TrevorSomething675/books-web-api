using BooksApi.Application.Repositories;
using Ardalis.Result.FluentValidation;
using BooksApi.Core.Shared;
using FluentValidation;
using Ardalis.Result;
using AutoMapper;
using MediatR;

namespace BooksApi.Infrastructure.Queries.AuthorFeatures.GetBookByIdQuery
{
    public class GetBookByIdQueryHandler(
        IMapper mapper,
        IBookRepository bookRepository,
        IValidator<GetBookByIdQuery> queryValidator
        ) : IRequestHandler<GetBookByIdQuery, Result<BookQueryModel>>
    {
        private readonly IMapper _mapper = mapper;
        private readonly IBookRepository _bookRepository = bookRepository;
        private readonly IValidator<GetBookByIdQuery> _queryValidator = queryValidator;

        public async Task<Result<BookQueryModel>> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            var validationResult = await _queryValidator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return Result<BookQueryModel>.Invalid(validationResult.AsErrors());

            var book = await _bookRepository.GetBookByIdAsync(request.Id);
            var bookModel = _mapper.Map<BookQueryModel>(book);

            return bookModel == null
                ? Result<BookQueryModel>.NotFound($"Книги с Id - {request.Id} не существует")
                : Result<BookQueryModel>.Success(bookModel);
        }
    }
}