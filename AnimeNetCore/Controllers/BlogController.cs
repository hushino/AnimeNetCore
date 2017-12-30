using System.Collections.Generic;
using AnimeNetCore.Data;
using AnimeNetCore.DAL;
using AnimeNetCore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AnimeNetCore.Controllers
{
    public class BlogController : Controller
    {
        private IBlogRepository _blogRepository;
        public static List<BlogViewModel> postList = new List<BlogViewModel>();

        public BlogController()
        {
            _blogRepository = new BlogRepository(new BlogDbContext());
        }

        public BlogController(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult index()
        {
            return View();
        }

        public ActionResult Posts()
        {
            postList.Clear();

            var posts = _blogRepository.GetPosts();
            foreach (var post in posts)
            {
                var postTags = GetPostTags(post);
                var postCategories = GetPostCategories(post);
                var likes = _blogRepository.LikeDislikeCount("postlike", post.Id);
                var dislikes = _blogRepository.LikeDislikeCount("postdislike", post.Id);
                postList.Add(new BlogViewModel()
                {
                    Post = post, Modified = post.Modified, Title = post.Title, ShortDescription = post.ShortDescription,
                    PostedOn = post.PostedOn, ID = post.Id, PostLikes = likes, PostDislikes = dislikes, PostCategories = postCategories, PostTags = postTags,
                    UrlSlug = post.UrlSeo
                });
            }
            return PartialView("Posts");
        }

       


        #region Helpers

        public IList<Post> GetPosts()
        {
            return _blogRepository.GetPosts();
        }

        public IList<Category> GetPostCategories(Post post)
        {
            return _blogRepository.GetPostCategories(post);
        }

        public IList<PostVideo> GetPostVideos(Post post)
        {
            return _blogRepository.GetPostVideos(post);
        }


        

        #endregion

    }
}