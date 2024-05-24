using Microsoft.AspNetCore.Mvc;
using WebApplication6.Models;
using System.Collections.Generic;
using WebApplication6.Data;

namespace WebApplication6.ViewComponents
{
	public class GenresViewComponent : ViewComponent
	{
		private readonly MovieContext _context;
		public GenresViewComponent(MovieContext context)
		{
			_context = context;
		}
		public IViewComponentResult Invoke()
		{
			@ViewBag.selectedGenre = RouteData.Values["id"];
			return View(_context.Genres.ToList());
		}
	}
}
