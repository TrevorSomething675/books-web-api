using BooksApi.Application.Repositories;
using Ardalis.Result.FluentValidation;
using BooksApi.Domain.Entities;
using BooksApi.Core.Shared;
using FluentValidation;
using Ardalis.Result;
using AutoMapper;
using MediatR;

namespace BooksApi.Infrastructure.Commands.BookFeature.UpdateBook
{
    public class UpdateBookCommandHandler(
        IMapper mapper,
        IBookRepository bookRepository,
        IValidator<UpdateBookCommand> commandValidator
        ) : IRequestHandler<UpdateBookCommand, Result<BookResponse>>
    {
        private readonly IMapper _mapper = mapper;
        private readonly IBookRepository _bookRepository = bookRepository;
        private readonly IValidator<UpdateBookCommand> _commandValidator = commandValidator;

        public async Task<Result<BookResponse>> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _commandValidator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return Result<BookResponse>.Invalid(validationResult.AsErrors());

            var book = _mapper.Map<Book>(request);
            var updatedBookId = await _bookRepository.UpdateBookAsync(book);
            return Result<BookResponse>.Success(
                new BookResponse(updatedBookId), "Книга была успешно редактирована");
        }
    }
}