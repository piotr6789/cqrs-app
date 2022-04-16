namespace CQRS.Domain
{
    public interface IPostRepository
    {
        Post GetPost(Guid guid);
        List<Post> GetPosts();
        void AddPost(Post post);
        void UpdatePost(Post post);
        void DeletePost(Guid guid);
    }
}
