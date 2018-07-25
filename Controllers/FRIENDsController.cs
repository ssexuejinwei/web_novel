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
    public class FRIENDsController : Controller
    {
        private NovelWeb db = new NovelWeb();

        // GET: FRIENDs
        public ActionResult Index()
        {
            string name = "00000030";
            IQueryable<FRIEND> list = from d in db.FRIEND where d.READERIDA == name || d.READERIDB == name select d;
            return View(list.ToList());
        }

        [HttpPost]
        public ActionResult Search_friend()
        {
            string name = Request.Form["name"];
            string guest = "00000030"/*Request.Cookies["_userid"].Value*/;
            IQueryable<FRIEND> list = from d in db.FRIEND where (d.READERIDB == name && d.READERIDA == guest) || (d.READERIDA == name && d.READERIDB == guest) select d;
            return View(list.ToList());
        }

        // GET: FRIENDs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FRIEND fRIEND = db.FRIEND.Find(id);
            if (fRIEND == null)
            {
                return HttpNotFound();
            }
            return View(fRIEND);
        }

        // GET: FRIENDs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FRIENDs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "READERIDA,READERIDB")] FRIEND fRIEND)
        {
            if (ModelState.IsValid)
            {
                db.FRIEND.Add(fRIEND);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fRIEND);
        }

        // GET: FRIENDs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FRIEND fRIEND = db.FRIEND.Find(id);
            if (fRIEND == null)
            {
                return HttpNotFound();
            }
            return View(fRIEND);
        }

        // POST: FRIENDs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "READERIDA,READERIDB")] FRIEND fRIEND)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fRIEND).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fRIEND);
        }

        // GET: FRIENDs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FRIEND fRIEND = db.FRIEND.Find(id);
            if (fRIEND == null)
            {
                return HttpNotFound();
            }
            return View(fRIEND);
        }

        // POST: FRIENDs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            FRIEND fRIEND = db.FRIEND.Find(id);
            db.FRIEND.Remove(fRIEND);
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
