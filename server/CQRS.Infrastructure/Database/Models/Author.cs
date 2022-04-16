using System.ComponentModel.DataAnnotations;

namespace CQRS.Infrastructure.Database.Models
{
    public class Author
    {
        [Key]
        public Guid AuthorId { get; set; }
        public string? Name { get; set; }
        public int? Age { get; set; }
        public ICollection<Post> Posts { get; set; }
    }
}
