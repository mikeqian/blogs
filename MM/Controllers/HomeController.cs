using System.Web.Mvc;
using Application;

namespace Mike.MM.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Blogs = BlogManager.GetBlogs();

            return View();
        }

        public ActionResult AboutMe()
        {
            return View();
        }
    }
}