
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
 using IMDB.ViewModels;
using System.Data.Entity;
using IMDB.DataLayer;

namespace IMDB.Controllers
{
    public class searchController : Controller
    {

        IMDBContext _context = new IMDBContext();
        SearchViewModel searchVM = new SearchViewModel();
        // GET: Search
        [HttpGet]
        public ActionResult Search()
        {
            searchVM.Actors = _context.Actors.ToList();
            searchVM.Directors = _context.Directors.ToList();
            searchVM.Movies = _context.Movies.ToList();
            return View(searchVM);
        }


        [HttpPost]
        public ActionResult Search(string SearchValue)
        {
            if (SearchValue == null)
            {

            }
            else
            {

                string[] SearchSplit = SearchValue.Split(' ');
                foreach (var item in SearchSplit)
                {
                    searchVM.Actors = _context.Actors.Where(ActorModel => ActorModel.FirstName.ToLower().StartsWith(item) || ActorModel.LastName.ToLower().StartsWith(item) || SearchValue == null);
                    searchVM.Directors = _context.Directors.Where(DirectorModel => DirectorModel.FirstName.ToLower().StartsWith(item) || DirectorModel.LastName.ToLower().StartsWith(item) || SearchValue == null);
                    searchVM.Movies = _context.Movies.Where(MovieModel => MovieModel.Movie_Name.ToLower().StartsWith(item) || SearchValue == null);
                }
            }
            return View(searchVM);
        }
    }
}