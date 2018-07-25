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
    public class SIGNINGsController : Controller
    {
        private NovelWeb db = new NovelWeb();

        // GET: SIGNINGs[功能点21：查总签约表]
        public ActionResult Index()
        {
            return View(db.SIGNING.ToList());
        }

        //GET:SIGNINGs/Name[功能点21：按名称查签约表]
        public ActionResult SearchSign(string cname)
        {
            cname = Request.Form["cname"];
            //IQueryable<SIGNING> Que = from q in db.SIGNING where q.NAME == cname select q;
            //List<SIGNING> list = Que.ToList();
            //return View(list);
            return View(db.SIGNING.Where(b => b.NAME.Contains(cname)).ToList());
        }
        

        // GET: SIGNINGs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SIGNING sIGNING = db.SIGNING.Find(id);
            if (sIGNING == null)
            {
                return HttpNotFound();
            }
            return View(sIGNING);
        }

        // GET: SIGNINGs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SIGNINGs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "WRITERID,NAME,STARTTIME,ENDTIME")] SIGNING sIGNING)
        {
            if (ModelState.IsValid)
            {
                db.SIGNING.Add(sIGNING);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sIGNING);
        }

        //[功能点12：增签约表]
        public ActionResult CreateSign()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateSign(SIGNING sign)
        {
            sign.WRITERID = Request.Form["w_id"];
            sign.NAME = Request.Form["c_name"];
            sign.STARTTIME = Request.Form["start"];
            sign.ENDTIME = Request.Form["end"];

            db.SIGNING.Add(sign);
            db.SaveChanges();

            return Content("<script>alert('签约成功！')</script>");
        }

        // GET: SIGNINGs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SIGNING sIGNING = db.SIGNING.Find(id);
            if (sIGNING == null)
            {
                return HttpNotFound();
            }
            return View(sIGNING);
        }

        // POST: SIGNINGs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "WRITERID,NAME,STARTTIME,ENDTIME")] SIGNING sIGNING)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sIGNING).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sIGNING);
        }

        // GET: SIGNINGs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SIGNING sIGNING = db.SIGNING.Find(id);
            if (sIGNING == null)
            {
                return HttpNotFound();
            }
            return View(sIGNING);
        }

        // POST: SIGNINGs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            SIGNING sIGNING = db.SIGNING.Find(id);
            db.SIGNING.Remove(sIGNING);
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
