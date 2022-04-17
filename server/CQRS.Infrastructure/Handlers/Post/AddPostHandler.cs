using CQRS.Domain.Core;
using CQRS.Domain.Models;
using CQRS.Infrastructure.Commands.PostCommands;
using MediatR;

namespace CQRS.Infrastructure.Handlers.PostHandlers
{
    public class AddPostHandler : IRequestHandler<AddPostCommand, Post>
    {
        private readonly IPostProvider _postProvider;

        public AddPostHandler(IPostProvider postProvider)
        {
            _postProvider = postProvider;
        }

        public Task<Post> Handle(AddPostCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_postProvider.AddPost(request.Post));
        }
    }
}
