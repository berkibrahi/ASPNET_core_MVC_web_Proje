using Microsoft.AspNetCore.Mvc;
using WebApplication6.Data;
//using WebApplication6.models;
using WebApplication6.Models;

namespace WebApplication6.Controllers
{
	public class HomeController : Controller
	{
		private readonly MovieContext _context;
		public HomeController(MovieContext context)
		{
			_context = context;
		}
		public IActionResult Index()

		{
			var model = new HomePageViewModel
			{
				popularMovies = _context.Movies.ToList(),

			};
			
			return View(model);
			
		}
	
		public IActionResult About()
		{
			
			return View();
		}
	}
}
