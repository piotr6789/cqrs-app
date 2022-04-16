namespace CQRS.Domain
{
    public interface IAuthorRepository
    {
        Author GetAuthorAsync(Guid guid);
        List<Author> GetAuthorsAsync(Guid guid);
        void AddAuthorAsync(Author post);
        void UpdateAuthorAsync(Author post);
        void DeleteAuthorAsync(Guid guid);
    }
}
