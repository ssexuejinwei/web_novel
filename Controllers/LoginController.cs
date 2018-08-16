using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
namespace WebApplication1.Controllers
{
    public class LoginController : Controller
    {
        private NovelWeb db = new NovelWeb();
        // GET: Login
        public ActionResult Index()
        {
           
            return View();
        }
        
        public ActionResult _login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult _login(Login user)
        {
           
            int success1 = 0;
            int success2 = 0;
            READER temp = new READER();
            foreach (var data in db.READER)
            {
                if (data.READERID == user.ID)
                {
                    if (data.PASSWORD == user.Password)
                    {
                       
                        temp = data;
                        success1 = 1;
                        break;
                    }
                    else
                    {
                        ModelState.AddModelError("Password", "密码错误");
                        return View();
                    }
                }
            }
            //在读者表中成功找到对应用户,将id存到cookies里
            if (success1 == 1)
            {
                HttpCookie cookie = new HttpCookie("_userID");
                cookie.Value = user.ID;
                cookie.Expires = DateTime.Now.AddDays(7);
                Response.Cookies.Add(cookie);
                //ViewBag.myid = Request["temp.READERNAME"];
                return RedirectToAction("index", "home");
            }
            else
            {
                foreach (var data in db.WRITER)
                {
                    if (data.WRITERID == user.ID)
                    {
                        if (data.PASSWORD == user.Password)
                        {
                            success2 = 1;
                            break;
                        }
                        else
                        {
                            ModelState.AddModelError("Password", "密码错误");
                            return View();
                        }
                    }
                }
                //在作者表中成功找到用户,将用户id存到cookie中
                if (success2 == 1)
                {
                    HttpCookie cookie = new HttpCookie("_userID");
                    cookie.Value = user.ID;
                    cookie.Expires = DateTime.Now.AddDays(7);
                    Response.Cookies.Add(cookie);
                    //ViewBag.myid = Request[user.ID];
                    return RedirectToAction("index", "home");
                }
            }
            ModelState.AddModelError("ID", "用户ID不存在");
            return View();
        }

        public ActionResult _exit()
        {
            string subkeyName;
            subkeyName = "_userid";
            HttpCookie aCookie = Request.Cookies["userInfo"];
            aCookie.Values.Remove(subkeyName);
            aCookie.Expires = DateTime.Now.AddDays(1);
            Response.Cookies.Add(aCookie);
            return RedirectToAction("index", "Home");
        }
    }
}
/*读取cookie的方法
 * if (Request.Cookies["_userid"] != null)
{
    string user_id = Request.Cookies["_userID"].Value;
}*/

/*IQueryable<READER> q1 = from d in db.READER where d.READERID == user.ID select d;
IQueryable<WRITER> q2 = from d in db.WRITER where d.WRITERID == user.ID select d;
List<READER> l1 = q1.ToList();
List<READER> l2 = q1.ToList();
if (l1 == null && l2 == null)
{
    ModelState.AddModelError("ID", "不存在该ID");
    return View();
}
else
{
    if (l1 != null)
    {
        if (l1[0].PASSWORD == user.Password)
        {
            HttpCookie cookie = new HttpCookie("_userID");
            cookie.Value = user.ID;
            cookie.Expires = DateTime.Now.AddDays(7);
            Response.Cookies.Add(cookie);
            ViewBag.myid = user.ID;
            return RedirectToAction("Index", "Home");
        }
    }
    else if (l2 != null)
    {
        if (l2[0].PASSWORD == user.Password)
        {
            HttpCookie cookie = new HttpCookie("_userID");
            cookie.Value = user.ID;
            cookie.Expires = DateTime.Now.AddDays(7);
            Response.Cookies.Add(cookie);
            ViewBag.myid = user.ID;
            return RedirectToAction("Index", "Home");
        }

    }
    ModelState.AddModelError("Password", "密码错误");
    return View();
}
}*/







