using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{

    public class HomeController : Controller
    {
        private NovelWeb db = new NovelWeb();

        public ActionResult Index()
        {
            return View();
        }




        public ActionResult About(string id)
        {
            ViewBag.Message = "Your application description page.";

            var test = id;

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult HomePage()
        {

            //上方展示5本书

            IQueryable<BOOK> list1 = from d in db.BOOK
                                     where (new string[] { "00000000", "00000001", "00000002", "00000003", "00000004" }).Contains(d.BOOKID)
                                     select d;
            var List = list1.ToList();
            //免费专区
            //查询五本免费的书并显示

            IQueryable<BOOK> list2 = from d in db.BOOK
                                     where d.PRICEPERCHAPTER == 0
                                     select d;
            var List2 = list2.ToList();
            for (int i = 0; i < 5; ++i)
            {
                List.Add(List2[i]);
            }


            return View(List);

        }
    }
}