
namespace GameZone.Services
{
    public class GameService : IGameService
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly string  _imagesPath;
       
        public GameService(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
            _imagesPath = $"{_webHostEnvironment.WebRootPath}{FileSettings.imgaesFiles}";

        }

        public IEnumerable<Game> GetAll()
        {
            return _context.Games
                .Include(g => g.category)
                .Include(g => g.GameDevices)
                .ThenInclude(d => d.Device)
                .AsNoTracking()
                .ToList();
        }

        public async Task Create(CreateGameFormVM game)
        {
           var CoverName = $"{Guid.NewGuid()}{Path.GetExtension(game.Cover.FileName)}";

            var path = Path.Combine(_imagesPath, CoverName);

            using var stream = File.Create(path);
            await game.Cover.CopyToAsync(stream);
           

            Game game1 = new Game()
            {
                Name = game.Name,
                Description = game.Description,
                CategoryId = game.CategoryId,
                Cover = CoverName,
                GameDevices  = game.SelectedDevices.Select(d => new GameDevice { DeviceID = d}).ToList(),

            };
            _context.Add(game1);
            _context.SaveChanges();
        }
    }
}
