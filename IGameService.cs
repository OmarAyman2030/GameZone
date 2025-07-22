namespace GameZone.Services
{
    public interface IGameService
    {
        IEnumerable<Game> GetAll();
        Task Create(CreateGameFormVM game);
    }
}
