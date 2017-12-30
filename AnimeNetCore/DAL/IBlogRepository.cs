using System;
using System.Collections.Generic;
using AnimeNetCore.Models;

namespace AnimeNetCore.DAL
{
    public interface IBlogRepository : IDisposable
    {
        IList<Post> GetPosts();
        IList<Category> GetPostCategories(Post post);
        IList<Tag> GetPostTags(Post post);
        IList<PostVideo> GetPostVideos(Post post);
        int LikeDislikeCount(string typeAndlike, string id);

        IList<Tag> GetTags();
        IList<Category> GetCategories();
    }
}
