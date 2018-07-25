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
    public class BOOKTAGsController : Controller
    {
        private NovelWeb db = new NovelWeb();
        

        // GET: BOOKTAGs/TAG[功能点20：按编号查书籍标签表]
        public ActionResult SearchID(string bid)
        {
            IQueryable<BOOKTAG> Que = from q in db.BOOKTAG where q.BOOKID == "bid" select q;
            List<BOOKTAG> list = Que.ToList();
            return View(list);
        }

        // GET: BOOKTAGs/TAG[功能点20：按名称查书籍标签表]
        public ActionResult SearchName(string bname)
        {
            BOOK temp = db.BOOK.Find(bname);
            IQueryable<BOOKTAG> Que = from q in db.BOOKTAG where q.BOOKID == temp.BOOKID select q;
            List<BOOKTAG> list = Que.ToList();
            return View(list);
        }
        // GET: BOOKTAGs
        public ActionResult Index()
        {
           /* List<BOOKTAG> mylist = db.BOOKTAG.ToList();
            foreach(var data in mylist)
            {
                if (data.BOOKID == "00000001")
                {
                    string i = data.BOOKTAG1;
                }
            }*/
            return View(db.BOOKTAG.ToList());
        }

        // GET: BOOKTAGs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BOOKTAG bOOKTAG = db.BOOKTAG.Find(id);
            if (bOOKTAG == null)
            {
                return HttpNotFound();
            }
            return View(bOOKTAG);
        }

        // GET: BOOKTAGs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BOOKTAGs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BOOKID,BOOKTAG1")] BOOKTAG bOOKTAG)
        {
            if (ModelState.IsValid)
            {
                db.BOOKTAG.Add(bOOKTAG);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bOOKTAG);
        }

        // GET: BOOKTAGs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BOOKTAG bOOKTAG = db.BOOKTAG.Find(id);
            if (bOOKTAG == null)
            {
                return HttpNotFound();
            }
            return View(bOOKTAG);
        }

        // POST: BOOKTAGs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BOOKID,BOOKTAG1")] BOOKTAG bOOKTAG)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bOOKTAG).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bOOKTAG);
        }

        // GET: BOOKTAGs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BOOKTAG bOOKTAG = db.BOOKTAG.Find(id);
            if (bOOKTAG == null)
            {
                return HttpNotFound();
            }
            return View(bOOKTAG);
        }

        // POST: BOOKTAGs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            BOOKTAG bOOKTAG = db.BOOKTAG.Find(id);
            db.BOOKTAG.Remove(bOOKTAG);
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
