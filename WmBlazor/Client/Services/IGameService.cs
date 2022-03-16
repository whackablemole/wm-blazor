namespace WmBlazor.Client.Services.GameService
{
    public interface IGameService
    {
        List<Game> Games { get; set; }
        List<Developer> Developers { get; set; }
        List<Publisher> Publishers { get; set; }

        Task GetPublishers();
        Task GetDevelopers();
        Task GetGames();

        Task<Game> GetSingleGame(int id);

        Task CreateGame(Game game);
        Task UpdateGame(Game game);

        Task DeleteGame(int id);
    }
}
