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
    public class WRITERsController : Controller
    {
        private NovelWeb db = new NovelWeb();

        // GET: WRITERs
      
        //注册
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(WRITER user)
        {
            int ifhave = 0;
            foreach (var data in db.WRITER)
            {
                if (data.WRITERID == user.WRITERID)
                {
                    ifhave = 1;
                    break;
                }
            }
            if (ifhave == 1)
            {
                Content("已存在用户名");
                return View();
            }
            else
            {
                db.WRITER.Add(user);
                db.SaveChanges();
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        // GET: WRITERs
        public ActionResult Index(string w_id)
        {
            w_id = Request.Cookies["_userid"].Value;
            IQueryable<WRITER> Que = from d in db.WRITER where d.WRITERID == w_id select d;
            List<WRITER> list = Que.ToList();
            return View(list);
        }

        //[通过点击作品数量查看作品信息]
        public ActionResult ProductDetail(string w_id)
        {
            w_id = Request.Cookies["_userid"].Value;
            IQueryable<BOOK> Que = from d in db.BOOK where d.WRITERID == w_id select d;
            List<BOOK> list = Que.ToList();
            return View(list);
        }


        [HttpPost]
        public ActionResult Search_friend()
        {
            string name = Request.Form["name"];
            IQueryable<WRITER> list = from d in db.WRITER where d.WRITERID == name select d;
            return View(list.ToList());
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
