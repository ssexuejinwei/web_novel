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
    public class READERsController : Controller
    {
        private NovelWeb db = new NovelWeb();

        [HttpPost]
        public ActionResult Search()
        {
            string name = Request.Form["name"];
            IQueryable<READER> list = from d in db.READER where d.READERID == name select d;
            return View(list.ToList());
        }

        //注册
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(READER user)
        {
            int ifhave = 0;
            foreach(var data in db.READER)
            {
                if (data.READERID == user.READERID)
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
                db.READER.Add(user);
                db.SaveChanges();
                return Content("<script>alert('成功注册')</script>");
            }
            //return RedirectToAction("Index", "Home");
        }


        // GET: READERs
        [HttpPost]
        [ValidateAntiForgeryToken]
        //[个人信息页：前端只显示NAME\SEX\EMAIL]
        public ActionResult Index(string r_id)
        {
            r_id = Request.Cookies["_userid"].Value;
            IQueryable<READER> Que = from d in db.READER where d.READERID == r_id select d;
            List<READER> list = Que.ToList();
            return View(list);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //[VIP页：前端只显示VIP]
        public ActionResult VIP(string r_id)
        {
            r_id = Request.Cookies["_userid"].Value;
            IQueryable<READER> Que = from d in db.READER where d.READERID == r_id select d;
            List<READER> list = Que.ToList();
            return View(list);
        }
        public ActionResult VIP(string r_id, decimal num)
        {
            r_id = Request.Cookies["_userid"].Value;
            READER rEADER = db.READER.Find(r_id);
            rEADER.VIPREST = rEADER.VIPREST + num;
            IQueryable<READER> Que = from d in db.READER where d.READERID == r_id select d;
            List<READER> list = Que.ToList();
            return View(list);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //[充值页：前端只显示余额]
        public ActionResult Recharge(string r_id)
        {
            r_id = Request.Cookies["_userid"].Value;
            IQueryable<READER> Que = from d in db.READER where d.READERID == r_id select d;
            List<READER> list = Que.ToList();
            return View(list);
        }
        public ActionResult Recharge(string r_id, decimal num)
        {
            r_id = Request.Cookies["_userid"].Value;
            READER rEADER = db.READER.Find(r_id);
            rEADER.BALANCE = rEADER.BALANCE + num;
            IQueryable<READER> Que = from d in db.READER where d.READERID == r_id select d;
            List<READER> list = Que.ToList();
            return View(list);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //[换阅票页：前端只显示余额和阅票数，比例1:10]
        public ActionResult Exchange(string r_id)
        {
            r_id = Request.Cookies["_userid"].Value;
            IQueryable<READER> Que = from d in db.READER where d.READERID == r_id select d;
            List<READER> list = Que.ToList();
            return View(list);
        }
        public ActionResult Exchange(string r_id, decimal num)
        {
            r_id = Request.Cookies["_userid"].Value;
            READER rEADER = db.READER.Find(r_id);
            rEADER.BALANCE = rEADER.BALANCE - num;
            rEADER.MONTHTICKET = rEADER.MONTHTICKET + num * 10;
            IQueryable<READER> Que = from d in db.READER where d.READERID == r_id select d;
            List<READER> list = Que.ToList();
            return View(list);
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
