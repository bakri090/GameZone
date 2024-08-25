namespace GameZone.Controllers
{
    public class GamesController : Controller
    {
        private readonly ICategoriesService _categoriesService;
        private readonly IDevicesService _devicesService;
        private readonly IGamesService _gamesService;

        public GamesController(ICategoriesService categoriesService,
            IDevicesService devicesService,
            IGamesService gamesService)
        {
            _categoriesService = categoriesService;
            _devicesService = devicesService;
            _gamesService = gamesService;
        }

        public async Task<IActionResult> Index()
        {
            var games = await _gamesService.GetAll();

            return View(games);
        }
        public IActionResult Create()
        {
            CreateGameFormViewModel viewModel = new()
            {
                Categories = _categoriesService.GetCategories(),
                Devices = _devicesService.GetDevices(),
            };
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateGameFormViewModel model)
        {
            if (!ModelState.IsValid) {
                model.Categories = _categoriesService.GetCategories();
                model.Devices = _devicesService.GetDevices();
                return View(model);
            }
            await _gamesService.Create(model);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Edit(int id) { 
            var game = _gamesService.GetById(id);
            if (game is null) { 
            return NotFound();
            }
            EditGameFormViewModel viewModel = new() { 
             Id = id,
             Name = game.Name,
             Description = game.Decsription,
             CategoryId = game.CategoryId,
             SelectedDevices = game.Devices.Select(d => d.DeviceId).ToList(),
             Categories = _categoriesService.GetCategories(),
             Devices = _devicesService.GetDevices(),
             CurrentCover = game.Cover,
            };
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(EditGameFormViewModel model)
		{
			if (!ModelState.IsValid)
			{
				model.Categories = _categoriesService.GetCategories();
				model.Devices = _devicesService.GetDevices();
				return View(model);
			}
			await _gamesService.Update(model);

            if (model is null)
                return BadRequest();

			return RedirectToAction(nameof(Index));
		}
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            bool isDeleted = _gamesService.Delete(id);

            
            return isDeleted ? Ok() : BadRequest();
        }
	}
}
