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
    public class COLLECTsController : Controller
    {
        private NovelWeb db = new NovelWeb();

        //点击收藏按钮后的操作
        public ActionResult Collect(string bookID)
        {
           
            //将该元组插入collect表
            COLLECT temp = new COLLECT();
            string readerID = Request.Cookies["_userid"].Value;
           
            //判断是否已经收藏了
            IQueryable<COLLECT> q = from d in db.COLLECT
                                    where d.BOOKID == bookID && d.READERID == readerID
                                    select d;
            List<COLLECT> list = q.ToList();
           
            //已经收藏过了
            if (list.Count != 0) return Content("<script>alert('您已经收藏过本书');window.location.href='/collect/index';</script>");
            if (ModelState.IsValid)
            {
                temp.BOOKID = bookID;
                temp.READERID = readerID;
                db.COLLECT.Add(temp);
               
               // return RedirectToAction("Index");
            }
            //return View(temp);

            //修改书籍表的收藏量属性
            foreach(var data in db.BOOK)
            {
                if (data.BOOKID == bookID)
                {
                    data.COLLECTNUM++;
                }
            }

            //修改读者表的收藏量属性
            foreach(var data in db.READER)
            {
                if (data.READERID == readerID)
                {
                    data.NUMCOLLECTBOOK++;
                }
            }
            db.SaveChanges();

            return Content("<script>alert('收藏成功');window.location.href='/collects/Index';</script>");
        }
        // GET: COLLECTs
        public ActionResult Index()
        {
            return View(db.COLLECT.ToList());
        }

        // GET: COLLECTs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COLLECT cOLLECT = db.COLLECT.Find(id);
            if (cOLLECT == null)
            {
                return HttpNotFound();
            }
            return View(cOLLECT);
        }

        // GET: COLLECTs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: COLLECTs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "READERID,BOOKID")] COLLECT cOLLECT)
        {
            if (ModelState.IsValid)
            {
                db.COLLECT.Add(cOLLECT);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cOLLECT);
        }

        // GET: COLLECTs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COLLECT cOLLECT = db.COLLECT.Find(id);
            if (cOLLECT == null)
            {
                return HttpNotFound();
            }
            return View(cOLLECT);
        }

        // POST: COLLECTs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "READERID,BOOKID")] COLLECT cOLLECT)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cOLLECT).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cOLLECT);
        }

        // GET: COLLECTs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COLLECT cOLLECT = db.COLLECT.Find(id);
            if (cOLLECT == null)
            {
                return HttpNotFound();
            }
            return View(cOLLECT);
        }

        // POST: COLLECTs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            COLLECT cOLLECT = db.COLLECT.Find(id);
            db.COLLECT.Remove(cOLLECT);
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
