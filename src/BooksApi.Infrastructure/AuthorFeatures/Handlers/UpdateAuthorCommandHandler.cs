using BooksApi.Infrastructure.AuthorFeatures.Responses;
using BooksApi.Infrastructure.AuthorFeatures.Commands;
using Ardalis.Result;
using MediatR;


namespace BooksApi.Infrastructure.AuthorFeatures.Handlers
{
    public class UpdateAuthorCommandHandler(
        
        ) : IRequestHandler<UpdateAuthorCommand, Result<UpdatedAuthorReponse>>
    {
        public Task<Result<UpdatedAuthorReponse>> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}