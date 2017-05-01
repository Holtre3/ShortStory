using ShortStoryReviewSite.CustomAttributes;
using ShortStoryReviewSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShortStoryReviewSite.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [AuthorizeOrRedirectAttribute(Roles = "SiteAdmin")]
        public ActionResult Admin()
        {
            return View();
        }
        public ActionResult DisplayFrontPageStories()
        {
            IEnumerable<Story> stories = new List<Story>();
            stories = db.Stories.ToList();
            stories = stories.OrderByDescending(s => s.Score).Take(3);

            ViewBag.FirstPlaceTitle = stories.ElementAt(0).Title;
            ViewBag.SecondPlaceTitle = stories.ElementAt(1).Title;
            ViewBag.ThirdPlaceTitle = stories.ElementAt(2).Title;

            ViewBag.FirstPlaceAuthor = stories.ElementAt(0).Author;
            ViewBag.SecondPlaceAuthor = stories.ElementAt(1).Author;
            ViewBag.ThirdPlaceAuthor = stories.ElementAt(2).Author;

            ViewBag.FirstPlaceScore = stories.ElementAt(0).Score;
            ViewBag.SecondPlaceScore = stories.ElementAt(1).Score;
            ViewBag.ThirdPlaceScore = stories.ElementAt(2).Score;

            return View();
        }
    }
}