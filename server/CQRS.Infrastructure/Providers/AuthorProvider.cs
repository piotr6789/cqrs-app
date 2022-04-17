using AutoMapper;
using CQRS.Domain.Models;
using CQRS.Domain.Core;
using CQRS.Infrastructure.Database;

namespace CQRS.Infrastructure.Providers
{
    public class AuthorProvider : IAuthorProvider
    {
        private static readonly IMapper _mapper = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Author, Database.Models.Author>()
                .ForMember(a => a.AuthorId, opt => opt.MapFrom(src => src.Id))
                .ReverseMap();
        }).CreateMapper();

        private readonly PostDbContext _dbContext;

        public AuthorProvider(PostDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Author AddAuthor(Author author)
        {
            var authorDb = _mapper.Map<Database.Models.Author>(author);
            _dbContext.Add(authorDb);
            _dbContext.SaveChanges();

            return author;
        }

        public Author? DeleteAuthor(Guid guid)
        {
            var authorDb = _dbContext.Authors.FirstOrDefault(a => a.AuthorId == guid);
            if (authorDb == null) return null;

            _dbContext.Authors.Remove(authorDb);
            _dbContext.SaveChanges();

            return _mapper.Map<Author>(authorDb);
        }

        public Author GetAuthor(Guid guid)
        {
            var authorDb = _dbContext.Authors
                .FirstOrDefault(a => a.AuthorId == guid);

            return _mapper.Map<Author>(authorDb);
        }

        public List<Author> GetAuthors()
        {
            var authorsDb = _dbContext.Authors;

            return _mapper.Map<List<Author>>(authorsDb);
        }

        public Author? UpdateAuthor(Author author)
        {
            var authorDb = _dbContext.Authors.FirstOrDefault(a => a.AuthorId == author.Id);
            if (authorDb == null) return null;

            _mapper.Map(author, authorDb);
            _dbContext.SaveChanges();

            return author;
        }
    }
}
