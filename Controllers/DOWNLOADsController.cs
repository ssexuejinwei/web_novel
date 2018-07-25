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
    public class DOWNLOADsController : Controller
    {
        private NovelWeb db = new NovelWeb();

        // GET: DOWNLOADs
        public ActionResult Index()
        {
            return View(db.DOWNLOAD.ToList());
        }
        //点击下载按钮后的操作
        public ActionResult Download(string bookid)
        {
            bookid = "00000114";
            string userid = "00000010";
            //string userid = Request.Cookies["_userID"].Value;
            IQueryable<DOWNLOAD> q = from d in db.DOWNLOAD
                                     where d.READERID == userid && d.BOOKID == bookid
                                     select d;
            List<DOWNLOAD> list = q.ToList();

            //表中已存在
            if (list.Count != 0)
            {
                return Content("<script>alert('正在下载');window.location.href='/books/Index';</script>");
            }
            DOWNLOAD temp = new DOWNLOAD();
            temp.BOOKID = bookid;
            temp.READERID = userid;
            db.DOWNLOAD.Add(temp);

            //更新相关的下载量
            foreach(var data in db.BOOK)
            {
                if (data.BOOKID == bookid)
                {
                    data.DOWNLOADNUM++;
                    break;
                }
            }
            //db.SaveChanges();
            //Response.Write("<script>alter('下载成功');</script>");

            return Content("<script>alert('正在下载');window.location.href='/books/Index';</script>");
        }
        // GET: DOWNLOADs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DOWNLOAD dOWNLOAD = db.DOWNLOAD.Find(id);
            if (dOWNLOAD == null)
            {
                return HttpNotFound();
            }
            return View(dOWNLOAD);
        }

        // GET: DOWNLOADs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DOWNLOADs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "READERID,BOOKID")] DOWNLOAD dOWNLOAD)
        {
            if (ModelState.IsValid)
            {
                db.DOWNLOAD.Add(dOWNLOAD);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dOWNLOAD);
        }

        // GET: DOWNLOADs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DOWNLOAD dOWNLOAD = db.DOWNLOAD.Find(id);
            if (dOWNLOAD == null)
            {
                return HttpNotFound();
            }
            return View(dOWNLOAD);
        }

        // POST: DOWNLOADs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "READERID,BOOKID")] DOWNLOAD dOWNLOAD)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dOWNLOAD).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dOWNLOAD);
        }

        // GET: DOWNLOADs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DOWNLOAD dOWNLOAD = db.DOWNLOAD.Find(id);
            if (dOWNLOAD == null)
            {
                return HttpNotFound();
            }
            return View(dOWNLOAD);
        }

        // POST: DOWNLOADs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            DOWNLOAD dOWNLOAD = db.DOWNLOAD.Find(id);
            db.DOWNLOAD.Remove(dOWNLOAD);
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
