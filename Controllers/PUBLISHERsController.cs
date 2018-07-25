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
    public class PUBLISHERsController : Controller
    {
        private NovelWeb db = new NovelWeb();

        // GET: PUBLISHERs[功能点13：查总出版商表]
        public ActionResult Index()
        {
            return View(db.PUBLISHER.ToList());
        }

        // GET: PUBLISHERs[功能点13：按名称查出版商表]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Search(string pname)
        {
            IQueryable<PUBLISHER> Que = from q in db.PUBLISHER where q.PUBLISHERNAME == "pname" select q;
            List<PUBLISHER> list = Que.ToList();
            return View(list);
        }
       

        // GET: PUBLISHERs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PUBLISHER pUBLISHER = db.PUBLISHER.Find(id);
            if (pUBLISHER == null)
            {
                return HttpNotFound();
            }
            return View(pUBLISHER);
        }

        // GET: PUBLISHERs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PUBLISHERs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PUBLISHERNAME,PUBLISHERLINK")] PUBLISHER pUBLISHER)
        {
            if (ModelState.IsValid)
            {
                db.PUBLISHER.Add(pUBLISHER);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pUBLISHER);
        }

        // GET: PUBLISHERs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PUBLISHER pUBLISHER = db.PUBLISHER.Find(id);
            if (pUBLISHER == null)
            {
                return HttpNotFound();
            }
            return View(pUBLISHER);
        }

        // POST: PUBLISHERs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PUBLISHERNAME,PUBLISHERLINK")] PUBLISHER pUBLISHER)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pUBLISHER).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pUBLISHER);
        }

        // GET: PUBLISHERs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PUBLISHER pUBLISHER = db.PUBLISHER.Find(id);
            if (pUBLISHER == null)
            {
                return HttpNotFound();
            }
            return View(pUBLISHER);
        }

        // POST: PUBLISHERs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            PUBLISHER pUBLISHER = db.PUBLISHER.Find(id);
            db.PUBLISHER.Remove(pUBLISHER);
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
