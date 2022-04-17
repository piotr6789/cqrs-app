using CQRS.Domain.Models;
using MediatR;

namespace CQRS.Infrastructure.Queries.PostQueries
{
    public record GetPostListQuery() : IRequest<List<Post>>;
}
