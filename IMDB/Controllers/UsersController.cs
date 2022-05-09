using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using IMDB.DataLayer;
using IMDB.Models;
using IMDB.ViewModels;

namespace IMDB.Controllers
{
    public class UsersController : Controller
    {
        private IMDBContext db = new IMDBContext();

        public ActionResult Home()
        {
            return View();
        }


        [HttpGet]
        // GET: Users/Create
        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignUp(User user, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    string pic = System.IO.Path.GetFileName(file.FileName);
                    string path = System.IO.Path.Combine(Server.MapPath("~/ViewAssets/"), pic);

                    file.SaveAs(path);

                    user.Image = pic;
                }
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Login");
            }

            return View();
        }


        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User login)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    bool validuser = db.Users.Any(User => User.Email.ToLower() == login.Email.ToLower() && User.Password == login.Password);
                    if (validuser)
                    {
                        FormsAuthentication.SetAuthCookie(login.User_ID.ToString(), true);
                        return RedirectToAction("EditProfile", "Users");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Invalid login credentials.");

                }
            }
            catch (NullReferenceException ex)
            {
                ModelState.AddModelError("", "Invalid login credentials.");

            }



            return View();
        }
        [HttpGet]
        public ActionResult EditProfile(int? id)
        {

            if (id != null)
            {
                var Profile = db.Users.SingleOrDefault(a => a.User_ID == id);
                if (Profile == null)
                {
                    return HttpNotFound();
                }

                 

                EditProfile studentIdentityDepartment = new EditProfile
                {
                    user = Profile,
                 };

                return View(studentIdentityDepartment);
            }
            else
            {
                return RedirectToAction("Home");
            }
        }
       
        [HttpPost]
        public ActionResult EditProfile(EditProfile user , int? id)
        {

            return View();
        }



    }
}
