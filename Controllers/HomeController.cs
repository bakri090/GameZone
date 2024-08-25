using GameZone.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GameZone.Controllers
{
	public class HomeController : Controller
	{
		private readonly IGamesService _gameService;

		public HomeController(IGamesService gameService)
		{
			_gameService = gameService;
		}

		public async Task<IActionResult> Index()
		{
			var games = await _gameService.GetAll();
			return View(games);
		}
		public  IActionResult Details(int id)
		{
			var game =  _gameService.GetById(id);
			if (game is null)
			{
				return NotFound();
			}
			return View(game);
		}
		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
