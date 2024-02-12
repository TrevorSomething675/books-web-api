using BooksApi.Infrastructure.AuthorFeatures.Responses;
using BooksApi.Infrastructure.AuthorFeatures.Commands;
using Ardalis.Result;
using AutoMapper;
using MediatR;

namespace BooksApi.Infrastructure.AuthorFeatures.Handlers
{
    public class RemoveAuthorCommandHandler(
        IMapper mapper
        )
        : IRequestHandler<RemoveAuthorCommand, Result<RemovedAuthorResponse>>
    {
        private readonly IMapper _mapper = mapper;

        public async Task<Result<RemovedAuthorResponse>> Handle(RemoveAuthorCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
