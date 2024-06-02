using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Yumms.Models;

namespace Yumms.Controllers
{
    public class HomeController : Controller
    {
        private YummsContext db = new YummsContext();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Wear()
        {
            var products = db.Products.Where(o => o.Product_TypeID == 1).ToList();
            return View(products);
        }
        public ActionResult Wear1()
        {
            var products = db.Products.Where(o => o.Product_TypeID == 2).ToList();
            return View(products);
        }
        public ActionResult Wear2()
        {
            var products = db.Products.Where(o => o.Product_TypeID == 3).ToList();
            return View(products);
        }
        public ActionResult Wear3()
        {
            var products = db.Products.Where(o => o.Product_TypeID == 4).ToList();
            return View(products);
        }
        public ActionResult Wear4()
        {
            var products = db.Products.Where(o => o.Product_TypeID == 5).ToList();
            return View(products);
        }
        public ActionResult Wear5()
        {
            var products = db.Products.Where(o => o.Product_TypeID == 6).ToList();
            return View(products);
        }
        public ActionResult Wear6()
        {
            var products = db.Products.Where(o => o.Product_TypeID == 7).ToList();
            return View(products);
        }
        public ActionResult Wear7()
        {
            var products = db.Products.Where(o => o.Product_TypeID == 8).ToList();
            return View(products);
        }
    }
}