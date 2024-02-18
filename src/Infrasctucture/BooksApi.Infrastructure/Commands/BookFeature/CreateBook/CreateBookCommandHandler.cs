using Ardalis.Result.FluentValidation;
using BooksApi.Application.Repositories;
using BooksApi.Core.Shared;
using FluentValidation;
using Ardalis.Result;
using MediatR;

namespace BooksApi.Infrastructure.Commands.BookFeature.CreateBook
{
    public class CreateBookCommandHandler(
        IValidator<CreateBookCommand> commandValidator,
        IBookRepository bookRepository
        ) 
        : IRequestHandler<CreateBookCommand, Result<BookCommandResponse>>
    {
        private readonly IBookRepository _bookRepository = bookRepository;
        private readonly IValidator<CreateBookCommand> _commandValidator = commandValidator;

        public async Task<Result<BookCommandResponse>> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _commandValidator.ValidateAsync(request);
            if (!validationResult.IsValid)
                return Result<BookCommandResponse>.Invalid(validationResult.AsErrors());

            var createdBookId = await _bookRepository.CreateBookAsync(request.Book);
            return Result<BookCommandResponse>.Success(
                new BookCommandResponse(createdBookId), "Книга была успешно добавлена");
        }
    }
}