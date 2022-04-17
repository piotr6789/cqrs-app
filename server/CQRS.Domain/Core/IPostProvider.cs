using CQRS.Domain.Models;

namespace CQRS.Domain.Core
{
    public interface IPostProvider
    {
        Post GetPost(Guid guid);
        List<Post> GetPosts();
        Post AddPost(Post post);
        Post? UpdatePost(Post post);
        Post? DeletePost(Guid guid);
    }
}
