using BooksApi.Application.Repositories;
using BooksApi.Core.Shared;
using Ardalis.Result;
using MediatR;

namespace BooksApi.Infrastructure.Queries.AuthorFeatures.GetBooksQuery
{
    public sealed class GetBooksQueryHandler(
        IBookRepository bookRepository
        ) : IRequestHandler<GetBooksQuery, Result<List<BookQueryModel>>>
    {
        private readonly IBookRepository _bookRepository = bookRepository;
        public async Task<Result<List<BookQueryModel>>> Handle(
            GetBooksQuery request, 
            CancellationToken cancellationToken)
        {
            var books = await _bookRepository.GetBooksAsync();
            throw new NotImplementedException();
            //var booksResponse = 
        }
    }
}