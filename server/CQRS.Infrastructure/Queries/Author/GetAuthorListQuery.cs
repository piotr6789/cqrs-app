using CQRS.Domain.Models;
using MediatR;

namespace CQRS.Infrastructure.Queries.AuthorQueries
{
    public record GetAuthorListQuery() : IRequest<List<Author>>;
}
