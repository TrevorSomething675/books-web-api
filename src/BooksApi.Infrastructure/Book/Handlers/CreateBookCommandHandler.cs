using BooksApi.Infrastructure.Book.Responses;
using BooksApi.Infrastructure.Book.Commands;
using BooksApi.Application.Repositories;
using Ardalis.Result;
using MediatR;

namespace BooksApi.Infrastructure.Book.Handlers
{
    public class CreateBookCommandHandler(
        IBookRepository bookRepository
        ) : IRequestHandler<CreateBookCommand, Result<CreatedBookResponse>>
    {
        private readonly IBookRepository _bookRepository = bookRepository;
        public async Task<Result<CreatedBookResponse>> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            await _bookRepository.CreateBookAsync(request?.Book);

            return Result<CreatedBookResponse>.Success(
                new CreatedBookResponse(request?.Book?.Id), "Successfully operation");
        }
    }
}