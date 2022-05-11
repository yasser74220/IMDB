
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IMDB.DataLayer;
using IMDB.ViewModels;
using System.Data.Entity;

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
                    searchVM.Actors = _context.Actors.Where(ActorModel => ActorModel.FirstName.StartsWith(item) || ActorModel.LastName.StartsWith(item) || SearchValue == null);
                    searchVM.Directors = _context.Directors.Where(DirectorModel => DirectorModel.FirstName.StartsWith(item) || DirectorModel.LastName.StartsWith(item) || SearchValue == null);
                    searchVM.Movies = _context.Movies.Where(MovieModel => MovieModel.Movie_Name.StartsWith(item) || SearchValue == null);
                }
            }
            return View(searchVM);
        }
    }
}