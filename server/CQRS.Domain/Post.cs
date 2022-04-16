namespace CQRS.Domain
{
    public class Post
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public Author Author { get; set; }
    }
}
