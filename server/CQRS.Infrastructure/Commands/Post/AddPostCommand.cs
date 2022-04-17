using CQRS.Domain.Models;
using MediatR;

namespace CQRS.Infrastructure.Commands.PostCommands
{
    public record AddPostCommand(Post Post) : IRequest<Post>;
}
