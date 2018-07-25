using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using PagedList;
namespace WebApplication1.Controllers
{
    public class BOOKsController : Controller
    {
        private NovelWeb db = new NovelWeb();

        //[功能点25：查书籍表]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Search(string bname)
        {
            IQueryable<BOOK> Que = from q in db.BOOK where q.BOOKNAME == "bname" select q;
            List<BOOK> list = Que.ToList();
            return View(list);
        }
        public ActionResult Index(int? page)
        {
            var books = from d in db.BOOK orderby d.BOOKNAME where d.COLLECTNUM <= 1 select d;
            int pagesize = 8;
            int pagenumber = (page ?? 1);
         
            
             return View(books.ToPagedList(pagenumber, pagesize));
            //IQueryable<BOOK> que = from d in db.BOOK orderby d.COLLECTNUM select d;        //rank
            //return View(que.ToList());
            /*return View(db.BOOK.ToList());*/
        }

        [HttpPost]
        public ActionResult Search()
        {
            string name = Request.Form["name"];
            return View(db.BOOK.Where(b => b.BOOKNAME.Contains(name)).ToList());
        }

        public ActionResult Rank()
        {
            IQueryable<BOOK> list = db.BOOK.OrderByDescending(p => p.DOWNLOADNUM/*COLLECTNUM，or other*/);
            return View(list.ToList());
        }

        // GET: BOOKs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BOOK bOOK = db.BOOK.Find(id);
            if (bOOK == null)
            {
                return HttpNotFound();
            }
            return View(bOOK);
        }
        // GET: BOOKs/Create
        public ActionResult Create()
        {
            ViewBag.hard_value = new List<SelectListItem>()
        {
            new SelectListItem()
            {Value="0",Text="玄幻" },
            new SelectListItem()
            {Value="1",Text="仙侠" }
        };
            return View();
        }

        // POST: BOOKs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create([Bind(Include = "BOOKNAME,PRICEPERCHAPTER")]BOOK book)
        {
            var value = Request.Form[3];

            if (ModelState.IsValid)
            {


                //bookID:查book表
                var que = db.BOOK.Count();
                var bookID = (que + 1).ToString();
                for (int i = 0; i < 8 - bookID.Length; i++)
                { bookID = '0' + bookID; }
                book.BOOKID = bookID;
                //writerID:当前
                string userid = Request.Cookies["_userid"].Value;
                //starttime,updateTime:当前时间
                book.STARTTIME = DateTime.Now.ToString("yyyy-MM-dd");
                book.UPDATETIME = DateTime.Now.ToString("yyyy-MM-dd");
                //downloadnum,collcectnum:0
                book.DOWNLOADNUM = 0;
                book.COLLECTNUM = 0;
                //ifend:0
                book.IFEND = 0;
                //其余字段留空
                db.BOOK.Add(book);

                BOOKTAG booktag = new BOOKTAG();
                booktag.BOOKID = bookID;
                if (value == "0")
                {
                    booktag.BOOKTAG1 = "玄幻";
                }
                else if (value == "1")
                {
                    booktag.BOOKTAG1 = "仙侠";
                }
                else
                { booktag.BOOKTAG1 = "二次元"; }

                //改作者表
                WRITER writer = db.WRITER.Find(userid);
                writer.NUMPRODUCTION = writer.NUMPRODUCTION + 1;
                db.BOOKTAG.Add(booktag);
                db.SaveChanges();


                return RedirectToAction("Index");
            }
            else return View();
        }

        // GET: BOOKs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BOOK bOOK = db.BOOK.Find(id);
            if (bOOK == null)
            {
                return HttpNotFound();
            }
            return View(bOOK);
        }

        // POST: BOOKs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BOOKID,BOOKNAME,WRITERID,STARTTIME,UPDATETIME,DOWNLOADNUM,COLLECTNUM,IFEND,DOWNLOADLINK,PRICEPERCHAPTER")] BOOK bOOK)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bOOK).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bOOK);
        }

        // GET: BOOKs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BOOK bOOK = db.BOOK.Find(id);
            if (bOOK == null)
            {
                return HttpNotFound();
            }
            return View(bOOK);
        }

        // POST: BOOKs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            BOOK bOOK = db.BOOK.Find(id);
            db.BOOK.Remove(bOOK);
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
