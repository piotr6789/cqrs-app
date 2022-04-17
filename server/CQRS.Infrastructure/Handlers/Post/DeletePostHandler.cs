using CQRS.Domain.Core;
using CQRS.Domain.Models;
using CQRS.Infrastructure.Commands.PostCommands;
using MediatR;

namespace CQRS.Infrastructure.Handlers.PostHandlers
{
    public class DeletePostHandler : IRequestHandler<DeletePostCommand, Post>
    {
        private readonly IPostProvider _postProvider;

        public DeletePostHandler(IPostProvider postProvider)
        {
            _postProvider = postProvider;
        }

        public Task<Post> Handle(DeletePostCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_postProvider.DeletePost(request.Id));
        }
    }
}
