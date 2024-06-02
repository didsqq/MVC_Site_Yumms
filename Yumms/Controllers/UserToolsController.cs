using _4232_pp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Yumms.Models;

namespace Yumms.Controllers
{
    public class UserToolsController : Controller
    {
        private YummsContext db = new YummsContext();
        private User user;
        private Order order;
        public ActionResult Exit()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("SignIn", "SignIn");
        }
        public ActionResult Orders()
        {
            // Получаем текущего пользователя из сессии
            var currentUser = (User)Session["CurrentUser"];
            if (currentUser != null)
            {
                // Фильтруем заказы, чтобы выбрать только заказы текущего пользователя
                var orders = db.Orders.Where(o => o.UserID == currentUser.UserID).ToList();
                return View(orders);
            }
            return RedirectToAction("SignIn", "SignIn");
        }
        public ActionResult Buy(int? id, int quantity)
        {
            UserRepositoriesImpl repo = new UserRepositoriesImpl(db);
            user = (User)Session["Currentuser"];
            Product product = db.Products.Find(id);

            if (product != null && user != null && quantity > 0 && quantity <= product.Count)
            {
                order = new Order
                {
                    ProductID = product.ProductID,
                    UserID = user.UserID,
                    Total_Amount = product.Price * quantity,
                    Status = "Новый заказ",
                    Product_Count = quantity,
                    Date = DateTime.Now
                };

                product.Count -= quantity;
                db.Orders.Add(order);
                db.SaveChanges();
            }

            return RedirectToAction("Orders");
        }
        public ActionResult Delete(int? id)
        {
            Order order = db.Orders.Find(id);
            db.Orders.Remove(order);
            db.SaveChanges();
            return RedirectToAction("Orders");
        }
        public ActionResult Order(int? id)
        {
            Order order = db.Orders.Find(id);
            order.Status = "Оформлен";
            db.SaveChanges();
            return RedirectToAction("Orders");
        }
    }
}
