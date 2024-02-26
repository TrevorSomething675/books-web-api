using BooksApi.Core.Abstractions.Repositories;
using BooksApi.Core.Shared;
using Ardalis.Result;
using AutoMapper;
using MediatR;

namespace BooksApi.Infrastructure.Queries.BookFeatures.GetBooksQuery
{
    public sealed class GetBooksQueryHandler(
        IMapper mapper,
        IBookRepository bookRepository
        ) : IRequestHandler<GetBooksQuery, Result<List<BookQueryModel>>>
    {
        private readonly IMapper _mapper = mapper;
        private readonly IBookRepository _bookRepository = bookRepository;
        public async Task<Result<List<BookQueryModel>>> Handle(
            GetBooksQuery request,
            CancellationToken cancellationToken)
        {
            var books = await _bookRepository.GetBooksAsync(request.PageNumber);
            var booksResponse = _mapper.Map<List<BookQueryModel>>(books);

            return Result<List<BookQueryModel>>.Success(booksResponse);
        }
    }
}