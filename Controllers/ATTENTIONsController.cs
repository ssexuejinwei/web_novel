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
    public class ATTENTIONsController : Controller
    {
        private NovelWeb db = new NovelWeb();
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index()
        {
            string r_id = Request.Cookies["_userid"].Value;
            IQueryable<ATTENTION> Que = from d in db.ATTENTION where d.READERID == r_id select d;
            List<ATTENTION> list = Que.ToList();
            return View(list);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "READERID,WRITERID")] ATTENTION aTTENTION)
        {
            if (ModelState.IsValid)
            {
                db.ATTENTION.Add(aTTENTION);
                db.SaveChanges();
                WRITER wRITER = db.WRITER.Find(aTTENTION.WRITERID);
                wRITER.NUMFANS = wRITER.NUMFANS + 1;

                return RedirectToAction("Index");
            }

            return View(aTTENTION);
        }

        // GET: ATTENTIONs/Delete/5
        public ActionResult Delete([Bind(Include = "READERID,WRITERID")] ATTENTION a)
        {
            ATTENTION aTTENTION = db.ATTENTION.Find(a);
            if (aTTENTION == null)
            {
                return HttpNotFound();
            }
            return View(aTTENTION);
        }

        // POST: ATTENTIONs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed([Bind(Include = "READERID,WRITERID")] ATTENTION aTTENTION)
        {
            db.ATTENTION.Remove(aTTENTION);
            db.SaveChanges();
            WRITER wRITER = db.WRITER.Find(aTTENTION.WRITERID);
            wRITER.NUMFANS = wRITER.NUMFANS - 1;
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
