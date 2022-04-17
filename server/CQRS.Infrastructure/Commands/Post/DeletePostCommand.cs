using CQRS.Domain.Models;
using MediatR;

namespace CQRS.Infrastructure.Commands.PostCommands
{
    public record DeletePostCommand(Guid Id) : IRequest<Post?>;
}
