using System.Collections.Generic;
using System.Linq;
using AnimeNetCore.Data;
using AnimeNetCore.DAL;
using AnimeNetCore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PagedList;


namespace AnimeNetCore.Controllers
{
    public class BlogController : Controller
    {
        private IBlogRepository _blogRepository;
        public static List<BlogViewModel> postList = new List<BlogViewModel>();
        public static List<AllPostsViewModel> CheckCatList = new List<AllPostsViewModel>();
        public static List<AllPostsViewModel> CheckTagList = new List<AllPostsViewModel>();

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
        public ActionResult index(int? page, string sortOrder, string searchString, string[] searchCategory, string[] searchTag)
        {
            CheckCatList.Clear();
            CheckTagList.Clear();
            CreateCatAndTagList();

            Posts(page, sortOrder, searchString, searchCategory, searchTag);
            return View();
        }

        public ActionResult Posts(int? page, string sortOrder, string searchString, string[] searchCategory, string[] searchTag)
        {
            postList.Clear();

            ViewBag.CurrentSort = sortOrder;
            ViewBag.CurrentSearchString = searchString;
            ViewBag.CurrentSearchCategory = searchCategory;
            ViewBag.CurrentSearchTag = searchTag;
            ViewBag.DateSortParm = string.IsNullOrEmpty(sortOrder) ? "date_desc" : "";
            ViewBag.TitleSortParm = sortOrder == "Title" ? "title_desc" : "Title";

            var posts = _blogRepository.GetPosts();
            foreach (var post in posts)
            {
                var postTags = GetPostTags(post);
                //var postTags = GetPostTags(post);
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

            if (searchString != null)
            {
                postList = postList.Where(x => x.Title.ToLower().Contains(searchString.ToLower())).ToList();
            }
            if (searchCategory != null)
            {
                List<BlogViewModel> newlist = new List<BlogViewModel>();
                foreach (var catName in searchCategory)
                {
                    foreach (var item in postList)
                    {
                        if (item.PostCategories.Where(x => x.Name == catName).Any())
                        {
                            newlist.Add(item);
                        }
                    }
                    foreach (var item in CheckCatList)
                    {
                        if (item.Category.Name == catName)
                        {
                            item.Checked = true;
                        }
                    }
                }
                postList = postList.Intersect(newlist).ToList();
            }
            if (searchTag != null)
            {
                List<BlogViewModel> newlist = new List<BlogViewModel>();
                foreach (var TagName in searchTag)
                {
                    foreach (var item in postList)
                    {
                        if (item.PostTags.Where(x => x.Name == TagName).Any())
                        {
                            newlist.Add(item);
                        }
                    }
                    foreach (var item in CheckTagList)
                    {
                        if (item.Tag.Name == TagName)
                        {
                            item.Checked = true;
                        }
                    }
                }
                postList = postList.Intersect(newlist).ToList();
            }

            switch (sortOrder)
            {
                case "date_desc":
                    postList = postList.OrderByDescending(x => x.PostedOn).ToList();
                    break;
                case "Title":
                    postList = postList.OrderBy(x => x.Title).ToList();
                    break;
                case "title_desc":
                    postList = postList.OrderByDescending(x => x.Title).ToList();
                    break;
                default:
                    postList = postList.OrderBy(x => x.PostedOn).ToList();
                    break;

            }

            int pageSize = 2;
            int pageNumber = (page ?? 1);

            return PartialView("Posts", postList.ToPagedList(pageNumber, pageSize));
        }


        //al declarar en Iblogrepository esto deja d tirar error antes de declar alli se debe pasar por blogrepository

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

        public IList<Tag> GetPostTags(Post post)
        {
            return _blogRepository.GetPostTags(post);
        }
        
        public void CreateCatAndTagList()
        {
            foreach (var ct in _blogRepository.GetCategories())
            {
                CheckCatList.Add(new AllPostsViewModel { Category = ct, Checked = false});
            }
            foreach (var tg in _blogRepository.GetTags())
            {
                CheckTagList.Add(new AllPostsViewModel { Tag = tg, Checked = false});
            }
        }

        #endregion

    }
}