using CQRS.Domain.Core;
using CQRS.Domain.Models;
using CQRS.Infrastructure.Commands.AuthorCommands;
using MediatR;

namespace CQRS.Infrastructure.Handlers.AuthorHandlers
{
    public class AddAuthorHandler : IRequestHandler<AddAuthorCommand, Author>
    {
        private readonly IAuthorProvider _authorProvider;

        public AddAuthorHandler(IAuthorProvider authorProvider)
        {
            _authorProvider = authorProvider;
        }

        public Task<Author> Handle(AddAuthorCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_authorProvider.AddAuthor(request.Author));
        }
    }
}
