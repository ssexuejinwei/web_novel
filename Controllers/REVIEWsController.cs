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
    public class REVIEWsController : Controller
    {
        private NovelWeb db = new NovelWeb();

        // GET: REVIEWs
        public ActionResult Index()
        {
            return View(db.REVIEW.ToList());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CONTENT")] REVIEW review)
        {
            if (ModelState.IsValid)
            {
                review.REVIEWDATE = DateTime.Now.ToString("yyyy-MM-dd");
                /*
                review.BOOKID
                review.CHAPTERID
                */


                var que = from p in db.REVIEW
                          group p by p.COMMENTID into g
                          select new { g.Key, COUNT = g.Count() };

                var ans = que.Count();
                var currentid = ans.ToString();
                for (int i = 0; i < 8 - currentid.Length; ++i)
                    currentid = "0" + currentid;
                review.COMMENTID = currentid;
                review.FLOORNUMBER = 0;
                string userid = Request.Cookies["_userid"].Value;
                review.ID = userid;
                db.REVIEW.Add(review);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(review);
        }

        //回复评论
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Reply([Bind(Include = "CONTENT")] REVIEW review)
        {
            if (ModelState.IsValid)
            {

                var que = from p in db.REVIEW
                          group p by p.COMMENTID into g
                          select new { g.Key, COUNT = g.Count() };

                //commentid从客户端获取

                var floorid = from q in que
                              where q.Key == ""
                              //where q.Key == commentid
                              select q.COUNT;

                //floorid = floorid + 1;
                //review.FLOORNUMBER = floorid;

                db.REVIEW.Add(review);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(review);
        }
        // GET: REVIEWs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            REVIEW rEVIEW = db.REVIEW.Find(id);
            if (rEVIEW == null)
            {
                return HttpNotFound();
            }
            return View(rEVIEW);
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
