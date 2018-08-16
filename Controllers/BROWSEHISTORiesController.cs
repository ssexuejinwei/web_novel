using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class BROWSEHISTORiesController : Controller
    {
        private NovelWeb db = new NovelWeb();

        // GET: BROWSEHISTORies/Search[功能点11：查浏览历史表]
        public ActionResult Search(string rid)
        {
            IQueryable<BROWSEHISTORY> Que = from q in db.BROWSEHISTORY where q.READERID == "rid" select q;
            List<BROWSEHISTORY> list = Que.ToList();
            return View(list);
        }
        // GET: BROWSEHISTORies
        public ActionResult Index()
        {
            return View(db.BROWSEHISTORY.ToList());
        }

        // GET: BROWSEHISTORies/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BROWSEHISTORY bROWSEHISTORY = db.BROWSEHISTORY.Find(id);
            if (bROWSEHISTORY == null)
            {
                return HttpNotFound();
            }
            return View(bROWSEHISTORY);
        }

        // GET: BROWSEHISTORies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BROWSEHISTORies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "READERID,BOOKID,CHAPTERID,TIME")] BROWSEHISTORY bROWSEHISTORY)
        {
            if (ModelState.IsValid)
            {
                db.BROWSEHISTORY.Add(bROWSEHISTORY);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bROWSEHISTORY);
        }

        // GET: BROWSEHISTORies/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BROWSEHISTORY bROWSEHISTORY = db.BROWSEHISTORY.Find(id);
            if (bROWSEHISTORY == null)
            {
                return HttpNotFound();
            }
            return View(bROWSEHISTORY);
        }

        // POST: BROWSEHISTORies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "READERID,BOOKID,CHAPTERID,TIME")] BROWSEHISTORY bROWSEHISTORY)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bROWSEHISTORY).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bROWSEHISTORY);
        }

        // GET: BROWSEHISTORies/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BROWSEHISTORY bROWSEHISTORY = db.BROWSEHISTORY.Find(id);
            if (bROWSEHISTORY == null)
            {
                return HttpNotFound();
            }
            return View(bROWSEHISTORY);
        }

        // POST: BROWSEHISTORies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            BROWSEHISTORY bROWSEHISTORY = db.BROWSEHISTORY.Find(id);
            db.BROWSEHISTORY.Remove(bROWSEHISTORY);
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
