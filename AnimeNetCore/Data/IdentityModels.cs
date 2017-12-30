using AnimeNetCore.Models;
using Microsoft.EntityFrameworkCore;

namespace AnimeNetCore.Data
{
    public class BlogDbContext : DbContext
    {
        public BlogDbContext()
        {
        }

        public BlogDbContext(DbContextOptions<BlogDbContext> options) : base(options)
        {
        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Reply> Replies { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<PostTag> PostTags { get; set; }
        public DbSet<PostCategory> PostCategories { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<PostVideo> PostVideos { get; set; }
        public DbSet<PostLike> PostLikes { get; set; }
        public DbSet<CommentLike> CommentLikes { get; set; }
        public DbSet<ReplyLike> ReplyLikes { get; set; }

        
        //Esto no es nesesario en mvc5
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PostCategory>()
                .HasKey(c => new { c.CategotyId, c.PostId });

            modelBuilder.Entity<PostTag>()
                .HasKey(c => new { c.PostId, c.TagId });
        }

        
        //Esto no es nesesario en mvc5
        public DbSet<AnimeNetCore.Models.BlogViewModel> BlogViewModel { get; set; }

    }
}
