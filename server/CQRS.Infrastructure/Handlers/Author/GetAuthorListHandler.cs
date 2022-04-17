using CQRS.Domain.Core;
using CQRS.Domain.Models;
using CQRS.Infrastructure.Queries.AuthorQueries;
using MediatR;

namespace CQRS.Infrastructure.Handlers.AuthorHandlers
{
    public class GetAuthorListHandler : IRequestHandler<GetAuthorListQuery, List<Author>>
    {
        private readonly IAuthorProvider _authorProvider;

        public GetAuthorListHandler(IAuthorProvider authorProvider)
        {
            _authorProvider = authorProvider;
        }

        public Task<List<Author>> Handle(GetAuthorListQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_authorProvider.GetAuthors());
        }
    }
}
