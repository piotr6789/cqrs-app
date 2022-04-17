using CQRS.Domain.Models;
using MediatR;

namespace CQRS.Infrastructure.Queries.PostQueries
{
    public record GetPostByIdQuery(Guid Id) : IRequest<Post>;
}
