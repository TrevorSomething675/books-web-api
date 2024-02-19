using BooksApi.Application.Repositories;
using Ardalis.Result.FluentValidation;
using BooksApi.Domain.Entities;
using BooksApi.Core.Shared;
using FluentValidation;
using Ardalis.Result;
using AutoMapper;
using MediatR;

namespace BooksApi.Infrastructure.Commands.BookFeature.CreateBook
{
    public class CreateBookCommandHandler(
        IMapper mapper,
        IValidator<CreateBookCommand> commandValidator,
        IBookRepository bookRepository,
        IAuthorRepository authorRepository) 
        : IRequestHandler<CreateBookCommand, Result<BookCommandResponse>>
    {
        private readonly IMapper _mapper = mapper;
        private readonly IBookRepository _bookRepository = bookRepository;
        private readonly IAuthorRepository _authorRepository = authorRepository;
        private readonly IValidator<CreateBookCommand> _commandValidator = commandValidator;

        public async Task<Result<BookCommandResponse>> Handle(
            CreateBookCommand request, 
            CancellationToken cancellationToken)
        {
            var validationResult = await _commandValidator.ValidateAsync(request);
            if (!validationResult.IsValid)
                return Result<BookCommandResponse>.Invalid(validationResult.AsErrors());

            if (_authorRepository.GetAuthorByIdAsync(request.AuthorId) == null)
                return Result<BookCommandResponse>.NotFound("Автора с таким Id не существует");

            var book = _mapper.Map<Book>(request);
            var createdBookId = await _bookRepository.CreateBookAsync(book);
            return Result<BookCommandResponse>.Success(
                new BookCommandResponse(createdBookId), "Книга была успешно добавлена");
        }
    }
}