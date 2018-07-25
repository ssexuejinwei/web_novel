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
    public class CHAPTERsController : Controller
    {
        private NovelWeb db = new NovelWeb();

        // GET: CHAPTERs/Create
        //上传新章节
        public ActionResult Create()
        {
            return View();
        }
    }
}


        // POST: CHAPTERs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
       /* [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CHAPTERNAME")] CHAPTER chapter)
        {
            if (ModelState.IsValid)
            {  //用当前书id查找chapter的数量
               //bookID:查book表
                BOOK book = db.CHAPTER.Find(bookid);
                var que = from p in db.CHAPTER
                          group p by p.BOOKID into g
                          select new { g.Key, CHAPTERCOUNT = g.Count() };

                if (que == null)
                { var chapterID = "00000000"; }
                else
                {
                    var ans = from q in que
                              where q.Key == bookid
                              select q.CHAPTERCOUNT;

                    var chapterID = (ans + 1).ToString();
                    for (int i = 0; i < 8 - chapterID.Length; i++)
                    { chapterID = '0' + chapterID; }

                    //将chapter的内容保存为txt
                    CHAPTER chapter = new CHAPTER();
                    string text = Request.Form[2];

                    //生成链接
                    var link = "C:\\novel\\" + bookid + "\\" + chapterID + ".txt";
                    chapter.CHAPTERCONTENT = link;
                    StreamWriter sw = new StreamWriter(link);
                    sw.Write(text);

                    db.CHAPTER.Add(chapter);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(chapter);
            }
        }
            //
            public ActionResult Buy()
            {   //查询Book表：每章价格
                BOOK book = db.BOOK.Find(bookid);
                var price = book.PRICEPERCHAPTER;
                //通过cookie获取当前的readerID
                string userid = Request.Cookies["_userid"].Value;
                //查询当前reader是否为会员
                READER reader = db.READER.Find(userid);
                var ifVIP = reader.VIPREST;
                if (ifVIP > 0)
                { price = price.Value * 0.8; }

                return View();
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BuyConfirmed(string readerID)
        {   //查询Book表：每章价格
            BOOK book = db.BOOK.Find(bookid);
            var price = book.PRICEPERCHAPTER;
            //通过cookie获取当前readerID
            string userid = Request.Cookies["_userid"].Value;
            //查是否会员
            READER reader = db.READER.Find(userid);
            //如果大于，修改余额，改下载表？
            var ifVIP = reader.VIPREST;
            var balance = reader.BALANCE;
            if (ifVIP > 0)
            { price = price.Value * 0.8; }
            if (balance > price)
            { balance = balance - price;
              db.SaveChanges();
              //return View;
            }
            //否则，提示余额不足
            else
            {//return View; 
            }
     
        }
        // GET: CHAPTERs
        public ActionResult Index()
        {
            return View(db.CHAPTER.ToList());
        }

        // GET: CHAPTERs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CHAPTER cHAPTER = db.CHAPTER.Find(id);
            if (cHAPTER == null)
            {
                return HttpNotFound();
            }
            return View(cHAPTER);
        }

        // GET: CHAPTERs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CHAPTERs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BOOKID,CHAPTERID,CHAPTERNAME,CHAPTERCONTENT")] CHAPTER cHAPTER)
        {
            if (ModelState.IsValid)
            {
                db.CHAPTER.Add(cHAPTER);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cHAPTER);
        }

        // GET: CHAPTERs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CHAPTER cHAPTER = db.CHAPTER.Find(id);
            if (cHAPTER == null)
            {
                return HttpNotFound();
            }
            return View(cHAPTER);
        }

        // POST: CHAPTERs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BOOKID,CHAPTERID,CHAPTERNAME,CHAPTERCONTENT")] CHAPTER cHAPTER)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cHAPTER).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cHAPTER);
        }

        // GET: CHAPTERs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CHAPTER cHAPTER = db.CHAPTER.Find(id);
            if (cHAPTER == null)
            {
                return HttpNotFound();
            }
            return View(cHAPTER);
        }

        // POST: CHAPTERs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            CHAPTER cHAPTER = db.CHAPTER.Find(id);
            db.CHAPTER.Remove(cHAPTER);
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
}*/
