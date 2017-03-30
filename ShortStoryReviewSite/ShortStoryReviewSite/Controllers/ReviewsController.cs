﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ShortStoryReviewSite.Models;

namespace ShortStoryReviewSite.Controllers
{
    public class ReviewsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Reviews
        [HttpGet]
        public ActionResult Index(string sortOrder)
        {
            IEnumerable <Review> reviews = from r in db.Reviews
                           select r;

            switch (sortOrder)
            {
                case "UserName":
                    reviews = reviews.OrderBy(r => r.UserName);
                    break;
                case "Score":
                    reviews = reviews.OrderBy(r => r.Score);
                    break;
                default:
                    reviews = reviews.OrderBy(r => r.ReviewDate);
                    break;
            }
            return View(reviews);
        }
        [HttpPost]
        public ActionResult Index(string searchCriteria, string cityFilter)
        {
            IEnumerable<Review> reviews = from r in db.Reviews
                                          select r;
            if (searchCriteria != null)
            {
                reviews = reviews.Where(r => r.ReviewText.Contains(searchCriteria));
            }
            return View(reviews);
        }
        public ActionResult ListOfReviewsByStory(int ID)
        {
            var storyReviews = db.Reviews
                .Where(a => a.StoryId == ID)
                .ToList();
            var story = db.Stories.Find(ID);
            ViewBag.StoryTitle = story.Title;
            return View(storyReviews);
        }
        [HttpGet]
        public ActionResult UserCreate()
        {

            return View();
        }
        [HttpPost]
        public ActionResult UserCreate(Review review, int ID)
        {
            if (ModelState.IsValid)
            {
                review.Id = ID;
                db.Reviews.Add(review);
                db.SaveChanges();
                return RedirectToAction("ListOfReviewsByBrewery", new { id = review.Id });
            }
            return View(review);
        }
        // GET: Reviews/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Review review = db.Reviews.Find(id);
            if (review == null)
            {
                return HttpNotFound();
            }
            return View(review);
        }

        // GET: Reviews/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Reviews/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,StoryId,UserName,Score,ReviewText,ReviewDate")] Review review)
        {
            if (ModelState.IsValid)
            {
                db.Reviews.Add(review);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(review);
        }

        // GET: Reviews/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Review review = db.Reviews.Find(id);
            if (review == null)
            {
                return HttpNotFound();
            }
            return View(review);
        }

        // POST: Reviews/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,StoryId,UserName,Score,ReviewText,ReviewDate")] Review review)
        {
            if (ModelState.IsValid)
            {
                db.Entry(review).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(review);
        }

        // GET: Reviews/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Review review = db.Reviews.Find(id);
            if (review == null)
            {
                return HttpNotFound();
            }
            return View(review);
        }

        // POST: Reviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Review review = db.Reviews.Find(id);
            db.Reviews.Remove(review);
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
