using BooksApi.Application.Repositories;
using BooksApi.Core.Shared;
using Ardalis.Result;
using MediatR;

namespace BooksApi.Infrastructure.Queries.AuthorFeatures.GetBookByIdQuery
{
    public class GetBookByIdQueryHandler(
        IBookRepository bookRepository
        ) : IRequestHandler<GetBookByIdQuery, Result<BookResponse>>
    {
        private readonly IBookRepository _bookRepository = bookRepository;

        public async Task<Result<BookResponse>> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            
        }
    }
}