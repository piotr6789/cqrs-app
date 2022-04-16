namespace CQRS.Domain
{
    public interface IAuthorRepository
    {
        Author GetAuthor(Guid guid);
        List<Author> GetAuthors();
        void AddAuthor(Author post);
        void UpdateAuthor(Author post);
        void DeleteAuthor(Guid guid);
    }
}
