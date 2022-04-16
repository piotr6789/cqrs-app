using CQRS.Infrastructure.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace CQRS.Infrastructure.Database
{
    public class PostDbContext : DbContext
    {
        public PostDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Author> Authors => Set<Author>();
        public DbSet<Post> Posts => Set<Post>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().HasIndex(a => a.AuthorId);
            modelBuilder.Entity<Post>()
                .HasOne(a => a.Author)
                .WithMany(p => p.Posts)
                .HasForeignKey(a => a.AuthorId);

            modelBuilder.Seed();
        }
    }

    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            #region generate authors
            var authors = new List<Author>()
            {
                new Author()
                {
                    AuthorId = Guid.NewGuid(),
                    Name = "Jan Kowalski",
                    Age = 27
                },
                new Author()
                {
                    AuthorId = Guid.NewGuid(),
                    Name = "Piotr Kowal",
                    Age = 30
                },
                new Author()
                {
                    AuthorId = Guid.NewGuid(),
                    Name = "Sebastian Nowicki",
                    Age = 33
                },

            };
            #endregion
            #region generate posts
            var posts = new List<Post>()
            {
                new Post()
                {
                    AuthorId = new Guid("C981AF1F-26AA-4469-9871-6D9EEF95955F"),
                    Date = new DateTime(2022, 4, 14),
                    PostId = Guid.NewGuid(),
                    Content = "Some conent"
                },
                new Post()
                {
                    AuthorId = new Guid("02612CC2-E2C0-4282-800A-CABDFED2AA76"),
                    Date = new DateTime(2022, 4, 15),
                    PostId = Guid.NewGuid(),
                    Content = "Some conent"
                },
                new Post()
                {
                    AuthorId = new Guid("F0A963B3-BDB6-448A-9A75-F73FB74B7902"),
                    Date = new DateTime(2022, 4, 16),
                    PostId = Guid.NewGuid(),
                    Content = "Some conent"
                },

            };
            #endregion

            //modelBuilder.Entity<Author>().HasData(authors[0]);
            //modelBuilder.Entity<Author>().HasData(authors[1]);
            //modelBuilder.Entity<Author>().HasData(authors[2]);
            modelBuilder.Entity<Post>().HasData(posts[0]);
            modelBuilder.Entity<Post>().HasData(posts[1]);
            modelBuilder.Entity<Post>().HasData(posts[2]);
        }
    }
}
