using System.ComponentModel.DataAnnotations;

namespace CQRS.Infrastructure.Database.Models
{
    public class Post
    {
        [Key]
        public Guid PostId { get; set; }
        public DateTime? Date { get; set; }
        public string Content { get; set; }
        public Guid AuthorId { get; set; }
        public Author Author { get; set; }
    }
}
