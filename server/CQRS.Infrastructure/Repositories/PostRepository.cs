using AutoMapper;
using CQRS.Domain;
using CQRS.Infrastructure.Database;

namespace CQRS.Infrastructure.Repositories
{
    public class PostRepository : IPostRepository
    {
        private static readonly IMapper _mapper = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Post, Database.Models.Post>();
            cfg.CreateMap<Author, Database.Models.Author>();
        }).CreateMapper();

        private readonly PostDbContext _dbContext;

        public PostRepository(PostDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddPostAsync(Post post)
        {
            var postDb = _mapper.Map<Database.Models.Post>(post);
            _dbContext.Add(postDb);
            _dbContext.SaveChanges();
        }

        public void DeletePostAsync(Guid guid)
        {
            var postDb = _dbContext.Posts.FirstOrDefault(p => p.PostId == guid);
            if (postDb == null) return;

            _dbContext.Posts.Remove(postDb);
            _dbContext.SaveChanges();
        }

        public Post GetPostAsync(Guid guid)
        {
            var postDb = _dbContext.Posts
                .FirstOrDefault(p => p.PostId == guid);

            return _mapper.Map<Post>(postDb);
        }

        public List<Post> GetPostsAsync(Guid guid)
        {
            var postsDb = _dbContext.Posts;

            return _mapper.Map<List<Post>>(postsDb);
        }

        public void UpdatePostAsync(Post post)
        {
            var postDb = _dbContext.Posts.FirstOrDefault(p => p.PostId == post.Id);
            if (postDb == null) return;

            _mapper.Map(post, postDb);
            _dbContext.SaveChanges();
        }
    }
}
