using System;
using System.Collections.Generic;
using AnimeNetCore.Models;

namespace AnimeNetCore.DAL
{
    public interface IBlogRepository : IDisposable
    {
        IList<Post> GetPosts();
        IList<Tag> GetPostTags(Post post);
        IList<Category> GetPostCategories(Post post);
        IList<PostVideo> GetPostVideos(Post post);
        int LikeDislikeCount(string typeAndlike, string id);
    }
}
