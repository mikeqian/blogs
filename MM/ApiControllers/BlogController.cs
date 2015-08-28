using System;
using System.Web.Http;
using Application;
using Mike.MM.Models.Base;
using MM.Domain.Entity;

namespace Mike.MM.ApiControllers
{
    public class BlogController : ApiController
    {
        [HttpPost]
        [Route("api/blog/add")]
        public object AddBlog(Blog blog)
        {
            if (blog != null && !string.IsNullOrWhiteSpace(blog.Content))
            {
                var text = System.Text.RegularExpressions.Regex.Replace(blog.Content, @"<[^>]*>", "");
                if (text.Length > 100)
                {
                    text = text.Substring(0, 100);
                }

                blog.ID = Guid.NewGuid().ToString("N");
                blog.Summary = text;
                blog.CreateTime = DateTime.Now;

                BlogManager.AddBlog(blog);

                return new JsonResponseModel { Success = true };
            }
            else
            {
                return new JsonResponseModel { Success = false };
            }
        }

        [HttpPost]
        [Route("api/blog/edit")]
        public object EditBlog(Blog blog)
        {
            if (blog != null && !string.IsNullOrWhiteSpace(blog.Content))
            {
                var text = System.Text.RegularExpressions.Regex.Replace(blog.Content, @"<[^>]*>", "");
                if (text.Length > 100)
                {
                    text = text.Substring(0, 100);
                }

                blog.Summary = text;
                blog.CreateTime = DateTime.Now;

                BlogManager.UpdateBlog(blog);

                return new JsonResponseModel { Success = true };
            }
            else
            {
                return new JsonResponseModel { Success = false };
            }
        }
    }
}
