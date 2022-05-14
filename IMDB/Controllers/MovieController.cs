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
        private int userID = 17;
        private int movieID = 1;
        // GET: Movie
        [HttpGet]
        public ActionResult Index(int movieId, int userId)
        {
            this.movieID = movieId;
            this.userID = userId;
            return RedirectToAction("MovieDetails");
        }
        [HttpGet]
        public ActionResult MovieDetails()
        {
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

            if (ModelState.IsValid)
            {
                db.Comments.Add(comment);
                db.SaveChanges();
                return RedirectToAction("MovieDetails");
            }
            return HttpNotFound();
        }

        public ActionResult like()
        {
            Like updateLike = db.Likes.SingleOrDefault(l => l.Movie_ID == movieID && l.User_ID == userID);
            if (updateLike == null)
            {
                updateLike.like = (userLike)1;
                updateLike.Movie_ID = movieID;
                updateLike.User_ID = userID;
                db.Likes.Add(updateLike);
                db.SaveChanges();

            }
            else
            {
                updateLike.like = (userLike)1;
                db.Entry(updateLike).State = EntityState.Modified;
            }
            return RedirectToAction("Index");
        }
        public ActionResult dislike()
        {
            Like updateLike = db.Likes.SingleOrDefault(l => l.Movie_ID == movieID && l.User_ID == userID);
            if (updateLike == null)
            {
                updateLike.like = (userLike)0;
                updateLike.Movie_ID = movieID;
                updateLike.User_ID = userID;
                db.Likes.Add(updateLike);
                db.SaveChanges();

            }
            else
            {
                updateLike.like = (userLike)1;
                db.Entry(updateLike).State = EntityState.Modified;
            }
            return RedirectToAction("Index");
        }


    }
}