using CQRS.Domain.Core;
using CQRS.Domain.Models;
using CQRS.Infrastructure.Queries.PostQueries;
using MediatR;

namespace CQRS.Infrastructure.Handlers.PostHandlers
{
    public class GetPostListHandler : IRequestHandler<GetPostListQuery, List<Post>>
    {
        private readonly IPostProvider _postProvider;

        public GetPostListHandler(IPostProvider postProvider)
        {
            _postProvider = postProvider;
        }

        public Task<List<Post>> Handle(GetPostListQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_postProvider.GetPosts());
        }
    }
}
