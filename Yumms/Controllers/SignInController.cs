using _4232_pp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Yumms.Models;

namespace Yumms.Controllers
{
    public class SignInController : Controller
    {
        // GET: SignIn
        private YummsContext db = new YummsContext();
        // GET: SignIn
        public ActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignIn(User user)
        {
            if (ModelState.IsValid)
            {
                User existingUser = new User();
                UserRepositoriesImpl repo = new UserRepositoriesImpl(db);
                try
                {
                    user.Password = GetHashString(user.Password);
                    //existingUser = db.Users.FirstOrDefault(c => c.Email == user.Email && c.Password == user.Password);
                    existingUser = repo.SignIn(user);
                }
                catch (ArgumentNullException ex)
                {
                    ModelState.AddModelError("", $"Пользователь не найден: {ex.Message}");
                }
                if (existingUser != null)
                {
                    Session["CurrentUser"] = existingUser;
                    if (existingUser.root == UserRole.ADMIN)
                    {
                        return RedirectToAction("AdminProfile", "Profile");
                    }
                    else
                    {
                        return RedirectToAction("Profile", "Profile");
                    }
                }
                ModelState.AddModelError("", "Ошибка ввода логина или пароля");
            }
            return View(user);
        }
        public static string GetHashString(string s)
        {
            byte[] bytes = Encoding.Unicode.GetBytes(s);
            MD5CryptoServiceProvider CSP = new MD5CryptoServiceProvider();
            byte[] byteHash = CSP.ComputeHash(bytes);
            string hash = "";
            foreach (byte b in byteHash)
            {
                hash += string.Format("{0:x2}", b);
            }
            return hash;
        }
    }
}
