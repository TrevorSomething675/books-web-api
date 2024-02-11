using BooksApi.Infrastructure.BookFeatures.Responses;
using BooksApi.Infrastructure.BookFeatures.Commands;
using BooksApi.Application.Repositories;
using BooksApi.Core.Entities;
using Ardalis.Result;
using AutoMapper;
using MediatR;

namespace BooksApi.Infrastructure.BookFeatures.Handlers
{
    public class CreateBookCommandHandler(
        IBookRepository bookRepository,
        IMapper mapper
        ) : IRequestHandler<CreateBookCommand, Result<CreatedBookResponse>>
    {
        private readonly IMapper _mapper = mapper;
        private readonly IBookRepository _bookRepository = bookRepository;
        public async Task<Result<CreatedBookResponse>> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var bookModel = _mapper.Map<Book>(request?.Book);
            await _bookRepository.CreateBookAsync(bookModel);

            return Result<CreatedBookResponse>.Success(
                new CreatedBookResponse(request?.Book?.Id), "Successfully operation");
        }
    }
}