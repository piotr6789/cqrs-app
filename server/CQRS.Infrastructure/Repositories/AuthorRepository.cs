using AutoMapper;
using CQRS.Domain;
using CQRS.Infrastructure.Database;

namespace CQRS.Infrastructure.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private static readonly IMapper _mapper = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Post, Database.Models.Post>()
                .ForMember(p => p.PostId, opt => opt.MapFrom(src => src.Id))
                .ReverseMap();
            cfg.CreateMap<Author, Database.Models.Author>()
                .ForMember(a => a.AuthorId, opt => opt.MapFrom(src => src.Id))
                .ReverseMap();
        }).CreateMapper();

        private readonly PostDbContext _dbContext;

        public AuthorRepository(PostDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void AddAuthor(Author author)
        {
            var authorDb = _mapper.Map<Database.Models.Author>(author);
            _dbContext.Add(authorDb);
            _dbContext.SaveChanges();
        }

        public void DeleteAuthor(Guid guid)
        {
            var authorDb = _dbContext.Authors.FirstOrDefault(a => a.AuthorId == guid);
            if (authorDb == null) return;

            _dbContext.Authors.Remove(authorDb);
            _dbContext.SaveChanges();
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

        public void UpdateAuthor(Author author)
        {
            var authorDb = _dbContext.Authors.FirstOrDefault(a => a.AuthorId == author.Id);
            if (authorDb == null) return;

            _mapper.Map(author, authorDb);
            _dbContext.SaveChanges();
        }
    }
}
