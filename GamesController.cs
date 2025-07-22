namespace GameZone.Controllers
{ 
    public class GamesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly Icategories _CategoriesServices;
        private readonly IDevices _DevicesServices;
        private readonly IGameService _GamesServices;

        public GamesController(ApplicationDbContext context, Icategories categoriesServices, IDevices devicesServices, IGameService gamesServices)
        {
            _context = context;
            _CategoriesServices = categoriesServices;
            _DevicesServices = devicesServices;
            _GamesServices = gamesServices;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            CreateGameFormVM viewModel = new()
            {
                Categories = _CategoriesServices.GetSelectLists(),

                Devices = _DevicesServices.GetSelectLists(),

            };
            return View(viewModel);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task <IActionResult> Create(CreateGameFormVM model)
        {
            if(!ModelState.IsValid)
            {
                model.Categories = _CategoriesServices.GetSelectLists();

                model.Devices = _DevicesServices.GetSelectLists();
                return View(model);
            }

            await _GamesServices.Create(model);

            return RedirectToAction(nameof(Index));
        }
    }
}
