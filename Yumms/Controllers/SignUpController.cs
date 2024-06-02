using _4232_pp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using Yumms.Models;

namespace Yumms.Controllers
{
    public class SignUpController : Controller
    {
        private YummsContext db = new YummsContext();
        // GET: SignUp

        [HttpGet]
        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(User user)
        {
            if (ModelState.IsValid)
            {
                string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
                if(user.Email != null && user.Password != null)
                {
                    if (!db.Users.Any(z => z.Email == user.Email))
                    {
                        if (Regex.IsMatch(user.Email, emailPattern))
                        {
                            UserRepositoriesImpl repo = new UserRepositoriesImpl(db);
                            user.Password = SignInController.GetHashString(user.Password);
                            repo.SaveUser(user);
                            return RedirectToAction("SignIn", "SignIn");
                        }
                        else
                        {
                            ModelState.AddModelError("", "Почта не подходит");
                            return View(user);
                        }
                    }
                    ModelState.AddModelError("", "Пользователь с такими данными уже существует.");
                }
                ModelState.AddModelError("", "Вы ничего не ввели");
            }
            return View(user);
        }
    }
}