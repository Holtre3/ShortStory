using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ShortStoryReviewSite.Models;
using ShortStoryReviewSite.CustomAttributes;
using System.ComponentModel;

namespace ShortStoryReviewSite.Controllers
{
    public class StoriesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Stories
        [AuthorizeOrRedirectAttribute(Roles = "SiteAdmin, StoryAdmin")]
        public ActionResult Index(string sortOrder, string searchCriteria)
        {
            IEnumerable<Story> stories = new List<Story>();
            stories = db.Stories.ToList();

            if (searchCriteria != null)
            {
                stories = stories.Where(story => story.Title.ToUpper().Contains(searchCriteria.ToUpper()));
            }

            switch (sortOrder)
            {
                case "Id":
                    stories = stories.OrderBy(story => story.Id);
                    break;
                case "Title":
                    stories = stories.OrderBy(story => story.Title);
                    break;
                case "Author":
                    stories = stories.OrderBy(story => story.Author);
                    break;
                case "Genre":
                    stories = stories.OrderBy(story => story.Genre);
                    break;
                case "Score":
                    stories = stories.OrderByDescending(story => story.Score);
                    break;
                case "SubmissionDate":
                    stories = stories.OrderBy(story => story.SubmissionDate.Date).ToList();
                    break;
                default:
                    stories = stories.OrderBy(story => story.Title);
                    break;
            }

            return View(stories);
        }
        public ActionResult ListStories(string sortOrder, string searchCriteria)
        {
            IEnumerable<Story> stories = new List<Story>();
            stories = db.Stories.ToList();
            if (searchCriteria != null)
            {
                stories = stories.Where(story => story.Title.ToUpper().Contains(searchCriteria.ToUpper()));
            }
            switch (sortOrder)
            {
                case "Id":
                    stories = stories.OrderBy(story => story.Id);
                    break;
                case "Title":
                    stories = stories.OrderBy(story => story.Title);
                    break;
                case "Author":
                    stories = stories.OrderBy(story => story.Author);
                    break;
                case "Genre":
                    stories = stories.OrderBy(story => story.Genre);
                    break;
                case "Score":
                    stories = stories.OrderByDescending(story => story.Score);
                    break;
                case "SubmissionDate":
                    stories = stories.OrderBy(story => story.SubmissionDate.Date).ToList();
                    break;
                default:
                    stories = stories.OrderBy(story => story.Title);
                    break;
            }
            return View(stories);
        }
        public ActionResult Search(string q)
        {
            var stories = db.Stories
                .Where(a => a.Title.Contains(q))
                .ToList();

            return View(stories);
        }

        // GET: Stories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Story story = db.Stories.Find(id);
            if (story == null)
            {
                return HttpNotFound();
            }
            return View(story);
        }

        // GET: Stories/Create

        [ValidateInput(false)]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Stories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //[ValidateInput(false)]
        public ActionResult Create([Bind(Include = "Id,Title,Author,StoryContent,Genre,Score,SubmissionDate")] Story story)
        {

            string text = Server.HtmlEncode(story.StoryContent);
            story.StoryContent = text;
            story.SubmissionDate = DateTime.Today;
            if (ModelState.IsValid)
            {
                db.Stories.Add(story);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(story);
        }

        // GET: Stories/Edit/5
        [AuthorizeOrRedirectAttribute(Roles = "SiteAdmin, StoryAdmin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Story story = db.Stories.Find(id);
            if (story == null)
            {
                return HttpNotFound();
            }
            return View(story);
        }

        // POST: Stories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AuthorizeOrRedirectAttribute(Roles = "SiteAdmin, StoryAdmin")]
        public ActionResult Edit([Bind(Include = "Id,Title,Author,StoryContent,Genre,Score,SubmissionDate")] Story story)
        {
            if (ModelState.IsValid)
            {
                db.Entry(story).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(story);
        }

        // GET: Stories/Delete/5
        [AuthorizeOrRedirectAttribute(Roles = "SiteAdmin, StoryAdmin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Story story = db.Stories.Find(id);
            if (story == null)
            {
                return HttpNotFound();
            }
            return View(story);
        }

        // POST: Stories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [AuthorizeOrRedirectAttribute(Roles = "SiteAdmin, StoryAdmin")]
        public ActionResult DeleteConfirmed(int id)
        {
            Story story = db.Stories.Find(id);
            db.Stories.Remove(story);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
