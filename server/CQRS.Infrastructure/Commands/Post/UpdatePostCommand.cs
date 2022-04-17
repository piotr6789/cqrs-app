using CQRS.Domain.Models;
using MediatR;

namespace CQRS.Infrastructure.Commands.PostCommands
{
    public record UpdatePostCommand(Post Post) : IRequest<Post?>;
}
