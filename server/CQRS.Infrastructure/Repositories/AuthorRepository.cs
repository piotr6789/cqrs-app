using AutoMapper;
using CQRS.Domain;
using CQRS.Infrastructure.Database;

namespace CQRS.Infrastructure.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private static readonly IMapper _mapper = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Post, Database.Models.Post>();
            cfg.CreateMap<Author, Database.Models.Author>();
        }).CreateMapper();

        private readonly PostDbContext _dbContext;

        public AuthorRepository(PostDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void AddAuthorAsync(Author author)
        {
            var authorDb = _mapper.Map<Database.Models.Author>(author);
            _dbContext.Add(authorDb);
            _dbContext.SaveChanges();
        }

        public void DeleteAuthorAsync(Guid guid)
        {
            var authorDb = _dbContext.Authors.FirstOrDefault(a => a.AuthorId == guid);
            if (authorDb == null) return;

            _dbContext.Authors.Remove(authorDb);
            _dbContext.SaveChanges();
        }

        public Author GetAuthorAsync(Guid guid)
        {
            var authorDb = _dbContext.Authors
                .FirstOrDefault(a => a.AuthorId == guid);

            return _mapper.Map<Author>(authorDb);
        }

        public List<Author> GetAuthorsAsync(Guid guid)
        {
            var authorsDb = _dbContext.Authors;

            return _mapper.Map<List<Author>>(authorsDb);
        }

        public void UpdateAuthorAsync(Author author)
        {
            var authorDb = _dbContext.Authors.FirstOrDefault(a => a.AuthorId == author.Id);
            if (authorDb == null) return;

            _mapper.Map(author, authorDb);
            _dbContext.SaveChanges();
        }
    }
}
