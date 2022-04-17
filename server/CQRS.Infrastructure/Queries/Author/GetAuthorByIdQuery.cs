using CQRS.Domain.Models;
using MediatR;

namespace CQRS.Infrastructure.Queries.AuthorQueries
{
    public record GetAuthorByIdQuery(Guid Id) : IRequest<Author>;
}
