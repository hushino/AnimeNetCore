﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnimeNetCore.Models;
using Microsoft.EntityFrameworkCore;

namespace AnimeNetCore.Data
{
    public class BlogDbContext : DbContext
    {
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

        
    }
}