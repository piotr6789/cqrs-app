using AutoMapper;
using CQRS.Domain;
using CQRS.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace CQRS.Infrastructure.Repositories
{
    public class PostRepository : IPostRepository
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

        public PostRepository(PostDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddPost(Post post)
        {
            var postDb = _mapper.Map<Database.Models.Post>(post);
            _dbContext.Add(postDb);
            _dbContext.SaveChanges();
        }

        public void DeletePost(Guid guid)
        {
            var postDb = _dbContext.Posts.FirstOrDefault(p => p.PostId == guid);
            if (postDb == null) return;

            _dbContext.Posts.Remove(postDb);
            _dbContext.SaveChanges();
        }

        public Post GetPost(Guid guid)
        {
            var postDb = _dbContext.Posts.Include(a => a.Author).FirstOrDefault(p => p.PostId == guid);

            return _mapper.Map<Post>(postDb);
        }

        public List<Post> GetPosts()
        {
            var postsDb = _dbContext.Posts.Include(a => a.Author);

            return _mapper.Map<List<Post>>(postsDb);
        }

        public void UpdatePost(Post post)
        {
            var postDb = _dbContext.Posts.FirstOrDefault(p => p.PostId == post.Id);
            if (postDb == null) return;

            _mapper.Map(post, postDb);
            _dbContext.SaveChanges();
        }
    }
}
