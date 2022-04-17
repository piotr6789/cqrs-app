using CQRS.Domain.Core;
using CQRS.Domain.Models;
using CQRS.Infrastructure.Commands.PostCommands;
using MediatR;

namespace CQRS.Infrastructure.Handlers.PostHandlers
{
    public class UpdatePostHandler : IRequestHandler<UpdatePostCommand, Post>
    {
        private readonly IPostProvider _postProvider;

        public UpdatePostHandler(IPostProvider postProvider)
        {
            _postProvider = postProvider;
        }

        public Task<Post> Handle(UpdatePostCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_postProvider.UpdatePost(request.Post));
        }
    }
}
