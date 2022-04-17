using CQRS.Domain.Core;
using CQRS.Domain.Models;
using CQRS.Infrastructure.Commands.AuthorCommands;
using MediatR;

namespace CQRS.Infrastructure.Handlers.AuthorHandlers
{
    public class UpdateAuthorHandler : IRequestHandler<UpdateAuthorCommand, Author?>
    {
        private readonly IAuthorProvider _authorProvider;

        public UpdateAuthorHandler(IAuthorProvider authorProvider)
        {
            _authorProvider = authorProvider;
        }

        public Task<Author?> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_authorProvider.UpdateAuthor(request.Author));
        }
    }
}
