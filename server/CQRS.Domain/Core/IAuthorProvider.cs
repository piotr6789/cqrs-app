using CQRS.Domain.Models;

namespace CQRS.Domain.Core
{
    public interface IAuthorProvider
    {
        Author GetAuthor(Guid guid);
        List<Author> GetAuthors();
        Author AddAuthor(Author post);
        Author? UpdateAuthor(Author post);
        Author? DeleteAuthor(Guid guid);
    }
}
