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
            string first = Request.Form["PASSWORD1"];
            string second = Request.Form["PASSWORD2"];
            if (first != second)
                return Content("<script>alert('两次密码输入不一致');window.location.href='/Readers/Register';</script>");

            int max = 0;
            foreach (var data in db.WRITER)
            {
                int a = Convert.ToInt32(data.WRITERID);
                if (a > max)
                    max = a;
            }
            max = max + 10;//读者是0结尾
            int temp = max;
            int figure = 1;
            for (int i = 0; temp != 0; i++)
            {
                temp = temp / 10;
                figure = i;

            }
            string add = null;
            while (figure != -1)
            {
                add += '0';
                figure--;
            }

            user.WRITERID = add + max.ToString();
            user.WRITERNAME = Request.Form["READERNAME"];
            user.PASSWORD = Request.Form["PASSWORD1"];
            user.EMAI = Request.Form["EMAI"];
            //添加到cookie
            HttpCookie cookie = new HttpCookie("_userID");
            cookie.Value = user.WRITERID;
            cookie.Expires = DateTime.Now.AddDays(7);
            Response.Cookies.Add(cookie);
            
            //保存数据库
            db.WRITER.Add(user);
            db.SaveChanges();
            return Content("<script>alert('注册成功，正在登录...');window.location.href='/Home/Index';</script>");
        }


        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //显示个人信息页面 
        public ActionResult Index()
        {
            //string w_id = Request.Cookies["_userid"].Value;
            string w_id = "00002221";
            if (w_id != null)
            {
                WRITER wRITER = db.WRITER.Find(w_id);
                ViewBag.name = wRITER.WRITERNAME;
                ViewBag.level = wRITER.WRITERLEVEL;
                ViewBag.fans = wRITER.NUMFANS;
                ViewBag.month = wRITER.MONTHTICKET;

                IQueryable<BOOK> Que = from d in db.BOOK where d.WRITERID == w_id select d;
                List<BOOK> list = Que.ToList();

                return View(list);
            }
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }

        //[通过点击作品数量查看作品信息]
        public ActionResult ProductDetail(string w_id)
        {
            w_id = Request.Cookies["_userid"].Value;
            IQueryable<BOOK> Que = from d in db.BOOK where d.WRITERID == w_id select d;
            List<BOOK> list = Que.ToList();
            return View(list);
        }
        
        // 修改个人信息
        public ActionResult Account()
        {
            //string w_id = Request.Cookies["_userid"].Value;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Account(WRITER wRITER)
        {
            //string w_id = Request.Cookies["_userid"].Value;
            string id = "00002221";
            WRITER m = db.WRITER.Find(id);
            if (m != null)
            {
                m.EMAI = Request.Form["email"];
                m.SEX = Request.Form["sex"];
                m.PASSWORD= Request.Form["password"];
                db.SaveChanges();
                return Content("<script>alert('修改成功');window.location.href='/WRITERs/account';</script>");
            }
            else
            {
                return Content("<script>alert('修改失败');window.location.href='/WRITERs/account';</script>");
            }
            
        
            
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
