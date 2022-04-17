using CQRS.Domain.Core;
using CQRS.Domain.Models;
using CQRS.Infrastructure.Queries.AuthorQueries;
using MediatR;

namespace CQRS.Infrastructure.Handlers.AuthorHandlers
{
    public class GetAuthorByIdHandler : IRequestHandler<GetAuthorByIdQuery, Author>
    {
        private readonly IAuthorProvider _authorProvider;

        public GetAuthorByIdHandler(IAuthorProvider authorProvider)
        {
            _authorProvider = authorProvider;
        }

        public Task<Author> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_authorProvider.GetAuthor(request.Id));
        }
    }
}
