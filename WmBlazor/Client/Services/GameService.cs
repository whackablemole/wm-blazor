using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace WmBlazor.Client.Services.GameService
{
    public class GameService : IGameService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;

        public GameService(HttpClient http, NavigationManager navigationManager)
        {
            _http = http;
            _navigationManager = navigationManager;
        }

        public List<Game> Games { get; set; } = new List<Game>();
        public List<Developer> Developers { get; set; } = new List<Developer>();
        public List<Publisher> Publishers { get; set; } = new List<Publisher>();

        public async Task SetGames(HttpResponseMessage result)
        {
            var response = await result.Content.ReadFromJsonAsync<List<Game>>();
            Games = response;
            _navigationManager.NavigateTo("games");
        }

        public async Task CreateGame(Game game)
        {
            var result = await _http.PostAsJsonAsync("api/game", game);
            await SetGames(result);
        }

        public async Task DeleteGame(int id)
        {
            var result = await _http.DeleteAsync($"api/game/{id}");
            await SetGames(result);
        }

        public async Task GetDevelopers()
        {
            var result = await _http.GetFromJsonAsync<List<Developer>>($"api/developer");
            if (result != null)
                Developers = result;
        }

        public async Task GetGames()
        {
            var result = await _http.GetFromJsonAsync<List<Game>>("api/game");
            if (result != null)
                Games = result;
        }

        public async Task GetPublishers()
        {
            var result = await _http.GetFromJsonAsync<List<Publisher>>($"api/publisher");
            if (result != null)
                Publishers = result;
        }

        public async Task<Game> GetSingleGame(int id)
        {
            var result = await _http.GetFromJsonAsync<Game>($"api/game/{id}");
            if (result != null)
                return result;
            throw new Exception("Game not found!");
        }

        public async Task UpdateGame(Game game)
        {
            var result = await _http.PutAsJsonAsync($"api/game", game);
            await SetGames(result);
        }
    }
}
