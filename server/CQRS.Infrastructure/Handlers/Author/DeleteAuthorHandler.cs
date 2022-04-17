using CQRS.Domain.Core;
using CQRS.Domain.Models;
using CQRS.Infrastructure.Commands.AuthorCommands;
using MediatR;

namespace CQRS.Infrastructure.Handlers.AuthorHandlers
{
    public class DeleteAuthorHandler : IRequestHandler<DeleteAuthorCommand, Author?>
    {
        private readonly IAuthorProvider _authorProvider;

        public DeleteAuthorHandler(IAuthorProvider authorProvider)
        {
            _authorProvider = authorProvider;
        }

        public Task<Author?> Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_authorProvider.DeleteAuthor(request.Id));
        }
    }
}
