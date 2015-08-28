using System.Web.Mvc;
using Application;

namespace Mike.MM.Controllers
{
    public class BlogController : Controller
    {
        [Route("blog/{id}")]
        public ActionResult Detail(string id)
        {
            ViewBag.Blog = BlogManager.GetBlog(id);

            return View();
        }

        [Route("blog/{id}/edit")]
        public ActionResult Edit(string id)
        {
            ViewBag.Blog = BlogManager.GetBlog(id);

            return View();
        }
    }
}