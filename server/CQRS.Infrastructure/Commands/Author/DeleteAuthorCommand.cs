using CQRS.Domain.Models;
using MediatR;

namespace CQRS.Infrastructure.Commands.AuthorCommands
{
    public record DeleteAuthorCommand(Guid Id) : IRequest<Author?>;
}
