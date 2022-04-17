using CQRS.Domain.Models;
using MediatR;

namespace CQRS.Infrastructure.Commands.AuthorCommands
{
    public record AddAuthorCommand(Author Author) : IRequest<Author>;
}
