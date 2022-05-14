using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IMDB.DataLayer;
using IMDB.Models;
using IMDB.ViewModels;
namespace IMDB.Controllers
{
    public class MovieController : Controller
    {
        private IMDBContext db = new IMDBContext();
  
        // GET: Movie
  
        [HttpGet]
        public ActionResult MovieDetails(string ID)
        {
            int movieID = Int32.Parse(ID);
            Session["MovieId"] = movieID;
            int userID = Int32.Parse(Session["Userid"].ToString());
            var movie = db.Movies.SingleOrDefault(m => m.Movie_ID == movieID);
            if (movie != null)
            {
                var userLike = db.Likes.SingleOrDefault(l => l.Movie_ID == movieID && l.User_ID == userID);
                MovieDetailsViewModel movieDetails = new MovieDetailsViewModel
                {
                    movie = movie,
                    userId = userID,
                    movieId = movieID,
                    hadRated = userLike == null ? false : true,
                    like = userLike,
                };

                return View(movieDetails);
            }
            else
            {
                return HttpNotFound();
            }
        }
        [HttpPost]
        public ActionResult MovieDetails(Comment comment)
        {   
            comment.User_ID = Int32.Parse(Session["Userid"].ToString());
            comment.Movie_ID = Int32.Parse(Session["MovieId"].ToString());
            if (ModelState.IsValid)
            {
                db.Comments.Add(comment);
                db.SaveChanges();
                return RedirectToAction("MovieDetails");
            }
            return HttpNotFound();
        }

  


    }
}