using CQRS.Domain.Models;
using MediatR;

namespace CQRS.Infrastructure.Commands.AuthorCommands
{
    public record UpdateAuthorCommand(Author Author) : IRequest<Author?>;
}
