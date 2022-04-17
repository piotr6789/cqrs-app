using CQRS.Domain.Core;
using CQRS.Domain.Models;
using CQRS.Infrastructure.Queries.PostQueries;
using MediatR;

namespace CQRS.Infrastructure.Handlers.PostHandlers
{
    public class GetPostByIdHandler : IRequestHandler<GetPostByIdQuery, Post>
    {
        private readonly IPostProvider _postProvider;

        public GetPostByIdHandler(IPostProvider postProvider)
        {
            _postProvider = postProvider;
        }

        public Task<Post> Handle(GetPostByIdQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_postProvider.GetPost(request.Id));
        }
    }
}
