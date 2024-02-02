using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebAppAssinment3.Models;

namespace WebAppAssinment3.Controllers
{
    public class PostDbsController : Controller
    {
        private PostDbEntities db = new PostDbEntities();

        // GET: PostDbs
        public ActionResult Index()
        {
            return View(db.PostDbs.ToList());
        }

        // GET: PostDbs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PostDb postDb = db.PostDbs.Find(id);
            if (postDb == null)
            {
                return HttpNotFound();
            }
            return View(postDb);
        }

        // GET: PostDbs/Create
        public ActionResult Create()
        {
            return View(new PostDb());
        }

        // POST: PostDbs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Pid,Title,Content,PublicationDate,Author")] PostDb postDb)
        {
            if (ModelState.IsValid)
            {
                db.PostDbs.Add(postDb);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(postDb);
        }

        // GET: PostDbs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PostDb postDb = db.PostDbs.Find(id);
            if (postDb == null)
            {
                return HttpNotFound();
            }
            return View(postDb);
        }

        // POST: PostDbs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Pid,Title,Content,PublicationDate,Author")] PostDb postDb)
        {
            if (ModelState.IsValid)
            {
                db.Entry(postDb).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(postDb);
        }

        // GET: PostDbs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PostDb postDb = db.PostDbs.Find(id);
            if (postDb == null)
            {
                return HttpNotFound();
            }
            return View(postDb);
        }

        // POST: PostDbs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PostDb postDb = db.PostDbs.Find(id);
            db.PostDbs.Remove(postDb);
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
