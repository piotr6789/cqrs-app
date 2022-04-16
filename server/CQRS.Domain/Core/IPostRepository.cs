namespace CQRS.Domain
{
    public interface IPostRepository
    {
        Post GetPostAsync(Guid guid);
        List<Post> GetPostsAsync(Guid guid);
        void AddPostAsync(Post post);
        void UpdatePostAsync(Post post);
        void DeletePostAsync(Guid guid);
    }
}
