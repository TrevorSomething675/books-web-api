using Ardalis.Result;
using Ardalis.Result.FluentValidation;
using BooksApi.Application.Repositories;
using BooksApi.Core.Shared;
using FluentValidation;
using MediatR;

namespace BooksApi.Infrastructure.Commands.BookFeature.CreateBook
{
    public class CreateBookCommandHandler(
        IValidator<CreateBookCommand> commandValidator,
        IBookRepository bookRepository
        ) 
        : IRequestHandler<CreateBookCommand, Result<BookResponse>>
    {
        private readonly IBookRepository _bookRepository = bookRepository;
        private readonly IValidator<CreateBookCommand> _commandValidator = commandValidator;

        public async Task<Result<BookResponse>> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _commandValidator.ValidateAsync(request);
            if (!validationResult.IsValid)
                return Result<BookResponse>.Invalid(validationResult.AsErrors());

            var createdBookId = await _bookRepository.CreateBookAsync(request.Book);
            return Result<BookResponse>.Success(
                new BookResponse(createdBookId), "Книга была успешно добавлена");
        }
    }
}