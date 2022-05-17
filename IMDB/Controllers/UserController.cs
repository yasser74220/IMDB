using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using IMDB.DataLayer;
using IMDB.Models;
using IMDB.ViewModels;

namespace IMDB.Controllers
{
    public class UserController : Controller
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
        public ActionResult Login(User user)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    User validuser = db.Users.FirstOrDefault(User => User.Email.ToLower() == user.Email.ToLower() && User.Password == user.Password);

                    if (validuser != null)
                    {
                        Session["Userid"] = validuser.User_ID;
                        Session["UserName"] = validuser.Fname + " " + validuser.Lname;
                        Session["UserImg"] = validuser.Image;
                        return RedirectToAction("EditProfile", new RouteValueDictionary(new { Controller = "User", Action = "EditProfile", Id = validuser.User_ID }));
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
                var user = db.Users.SingleOrDefault(a => a.User_ID == id);
                if (user == null)
                {
                    return HttpNotFound();
                }

                var favMovies = db.UserMovies.Where(x => x.User_ID == id).ToList();
                var favActors = db.UserActors.Where(x => x.User_ID == id).ToList();
                var favDirectors = db.UserDirectors.Where(x => x.User_ID == id).ToList();

                EditProfile edit = new EditProfile
                {
                    User = user,
                    TempUser = user,
                    FavouriteMovies = favMovies,
                    FavouriteActors = favActors,
                    FavouriteDirectors = favDirectors
                };

                return View(edit);
            }
            else
            {
                return RedirectToAction("Home");
            }
        }

        [HttpPost]
        public ActionResult EditProfile(EditProfile profile, HttpPostedFileBase file)
        {

            try
            {
                if (file != null)
                {
                    string pic = System.IO.Path.GetFileName(file.FileName);
                    string path = System.IO.Path.Combine(Server.MapPath("~/Images/"), pic);

                    file.SaveAs(path);

                    profile.User.Image = pic;
                }

                db.Entry(profile.User).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("EditProfile", new RouteValueDictionary(new { Controller = "User", Action = "EditProfile", Id = profile.User.User_ID }));

            }
            catch
            {
                return RedirectToAction("EditProfile", new RouteValueDictionary(new { Controller = "User", Action = "EditProfile", Id = profile.User.User_ID }));
            }
        }



        [HttpGet]
        public ActionResult Favourites(int? id)
        {

            if (id != null)
            {
                var user = db.Users.SingleOrDefault(a => a.User_ID == id);
                if (user == null)
                {
                    return HttpNotFound();
                }

                var movies = db.Movies.ToList();
                var actors = db.Actors.ToList();
                var directors = db.Directors.ToList();

                var favMovies = db.UserMovies.Where(x => x.User_ID == id).ToList();
                var favActors = db.UserActors.Where(x => x.User_ID == id).ToList();
                var favDirectors = db.UserDirectors.Where(x => x.User_ID == id).ToList();

                EditProfile edit = new EditProfile
                {
                    User = user,
                    TempUser = user,
                    Movies = movies,
                    Actors = actors,
                    Directors = directors,
                    FavouriteMovies = favMovies,
                    FavouriteActors = favActors,
                    FavouriteDirectors = favDirectors
                };

                return View(edit);
            }
            else
            {
                return RedirectToAction("Home");
            }
        }


        [HttpPost]
        public ActionResult Favourites(EditProfile profile)
        {

            try
            {
                foreach (var favMovieId in profile.FavouriteMoviesIds)
                {
                    var favMovie = db.UserMovies.Single(x => x.Movie_ID == favMovieId && profile.User.User_ID == x.User_ID);
                    db.Entry(favMovie).State = System.Data.Entity.EntityState.Modified;
                }
                foreach (var favActorId in profile.FavouriteActorsIds)
                {
                    var favActor = db.UserActors.Single(x => x.Actor_ID == favActorId && profile.User.User_ID == x.User_ID);

                    db.Entry(favActor).State = System.Data.Entity.EntityState.Modified;
                }
                foreach (var favDirectorId in profile.FavouriteDirectorsIds)
                {
                    var favDirector = db.UserDirectors.Single(x => x.Director_ID == favDirectorId && profile.User.User_ID == x.User_ID);

                    db.Entry(favDirector).State = System.Data.Entity.EntityState.Modified;
                }
                db.SaveChanges();

                return RedirectToAction("EditProfile", new RouteValueDictionary(new { Controller = "User", Action = "EditProfile", Id = profile.User.User_ID }));

            }
            catch
            {
                return RedirectToAction("EditProfile", new RouteValueDictionary(new { Controller = "User", Action = "EditProfile", Id = profile.User.User_ID }));
            }
        }

    }
}