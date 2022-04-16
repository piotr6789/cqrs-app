namespace CQRS.Domain
{
    public class Author
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public List<Post> Posts { get; set; }
    }
}
