using _4232_pp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Yumms.Models;

namespace Yumms.Controllers
{
    public class ProfileController : Controller
    {
        private YummsContext db = new YummsContext();
        // GET: Profile
        [HttpGet]
        public ActionResult Profile()
        {
            var User = (User)Session["CurrentUser"];
            if (User == null)
            {
                return View("~/Views/SignIn/SignIn.cshtml");
            }
            return View(User);
        }
        [HttpGet]
        public ActionResult AdminProfile()
        {
            var User = (User)Session["CurrentUser"];
            if (User == null)
            {
                return View("~/Views/SignIn/SignIn.cshtml");
            }
            return View(User);
        }
        public ActionResult Delete(int? id)
        {
            UserRepositoriesImpl repo = new UserRepositoriesImpl(db);
            User user = db.Users.Find(id);
            repo.DeleteUser(user);
            HttpContext.Session.Clear();
            return RedirectToAction("SignIn", "SignIn");
        }
        public ActionResult Edit(User Useredit)
        {
            if (ModelState.IsValid)
            {
                UserRepositoriesImpl repo = new UserRepositoriesImpl(db);

                User User = (User)Session["CurrentUser"];
                User usersave = repo.GetUserByEmail(User.Email);
                if (User != null)
                {
                    usersave.Name = Useredit.Name;
                    usersave.Password = SignInController.GetHashString(Useredit.Password);
                    User = usersave;
                    repo.UpdateUser(User);
                    Session["CurrentUser"] = usersave;
                    if (usersave.root == UserRole.ADMIN)
                    {
                        return RedirectToAction("AdminProfile");
                    }
                    else
                    {
                        return RedirectToAction("Profile");
                    }
                }
            }
            return View(Useredit);
        }
    }
}