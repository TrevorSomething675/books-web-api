using BooksApi.Application.Repositories;
using Ardalis.Result.FluentValidation;
using BooksApi.Core.Shared;
using FluentValidation;
using Ardalis.Result;
using MediatR;

namespace BooksApi.Infrastructure.Commands.BookFeature.RemoveBook
{
    public class RemoveBookCommandHandler(
        IBookRepository bookRepository,
        IValidator<RemoveBookCommand> commandValidator
        ) : IRequestHandler<RemoveBookCommand, Result<BookResponse>>
    {
        private readonly IBookRepository _bookRepository = bookRepository;
        private readonly IValidator<RemoveBookCommand> _commandValidator = commandValidator;
        public async Task<Result<BookResponse>> Handle(RemoveBookCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _commandValidator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return Result<BookResponse>.Invalid(validationResult.AsErrors());

            var removedBookId = await _bookRepository.RemoveBookAsync(request.Id);
            return Result<BookResponse>.Success(
                new BookResponse(removedBookId), "Книга была успешно удалена");
        }
    }
}