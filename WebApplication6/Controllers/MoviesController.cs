using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication6.Data;
using WebApplication6.Entity;
//using WebApplication6.models;
using WebApplication6.Models;

namespace WebApplication6.Controllers
{
    public class MoviesController : Controller

    {
		private readonly MovieContext _context;
        public MoviesController(MovieContext context) 
        {
			_context = context;
        }
        public IActionResult Index()
        {


			
				return View();

			}
		public IActionResult List(int? id ,string q)

		{
			//	var controller = RouteData.Values["controller"];
			//	var action = RouteData.Values["action"];
			//	var genreid = RouteData.Values["id"];
			//var kelime = HttpContext.Request.Query["q"].ToString();
			//var movies = MovieRepository.Movies;
			var movies = _context.Movies.AsQueryable();

			if (id != null)
			{
				movies = movies.Include(m=>m.Genres).Where(m => m.Genres.Any(g => g.genreId==id));
			}
			if (!string.IsNullOrEmpty(q))
			{
				movies = movies.Where(i => i.title.ToLower().Contains(q.ToLower())| i.description.ToLower().Contains(q.ToLower()));
			}


            var model = new MoviesViewModels()
			{
				Moviess = movies.ToList(),

			};
			return View(model);
		}
		public IActionResult Details(int id)
		{
			return View(_context.Movies.Find(id));
		}
		[HttpGet]
		public IActionResult Create() {
            ViewBag.Genres = new SelectList(_context.Genres.ToList(), "genreId", "Name");

            return View(); }
        [HttpPost]
        public IActionResult Create(Movie m)
        {
			//if (ModelState.IsValid)
			//{


			//         }
			//         ViewBag.Genres = new SelectList(GenreRepository.Genres, "genreId", "Name");
			//         return View(m);
			//MovieRepository.Add(m);
			_context.Movies.Add(m);
			_context.SaveChanges();
			TempData["message"] = $"{m.title} isimli film oluşturuldu";
			return RedirectToAction("List");
		}
		[HttpGet]
		public IActionResult Edit(int id) {
			ViewBag.Genres = new SelectList(_context.Genres.ToList(), "genreId", "Name");
			return View(_context.Movies.Find(id)); 
		}
        [HttpPost]
        public IActionResult Edit(Movie m)
        {
			//MovieRepository.Edit(m);
			//MovieRepository.Add(m);
			_context.Movies.Update(m);
			_context.SaveChanges();
			TempData["message"] = $"{m.title} isimli film güncellendi";
			return RedirectToAction("List");
			return RedirectToAction("Details",new {@id=m.movieId});
        }
        [HttpPost]
        public IActionResult Delete(int movieId, string title)
        {
			//MovieRepository.Delete(movieId);
			var entity = _context.Movies.Find(movieId);
			_context.Movies.Remove(entity);
			_context.SaveChanges();
			TempData["message"] = $"{title} isimli film silindi";
            return RedirectToAction("List");
        }


    }
}
