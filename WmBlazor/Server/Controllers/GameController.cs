using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WmBlazor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public GameController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<Game>>> Get()
        {
            return Ok(await _dataContext.Games.Include(game => game.Developer).ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Game>>> Get(int id)
        {
            var dbGame = _dataContext.Games.Include(game => game.Developer).FirstOrDefault(game => game.Id == id);
            if (dbGame == null)
                return BadRequest("Game not found.");

            return Ok(dbGame);
        }

        [HttpPost, Authorize(Roles = "Admin")]
        public async Task<ActionResult<Game>> AddGame(Game game)
        {
            _dataContext.Games.Add(game);
            await _dataContext.SaveChangesAsync();
            // Once it is saved, the primary key will be added to the existing game as an Id, so we can then use it to fetch the newly added game
            return Ok(await _dataContext.Games.FindAsync(game.Id));
        }

        [HttpPut, Authorize(Roles = "Admin")]
        public async Task<ActionResult<Game>> UpdateGame(Game request)
        {
            var dbGame = await _dataContext.Games.FindAsync(request.Id);
            if (dbGame == null)
                return BadRequest("Game not found.");

            dbGame.Name = request.Name;
            dbGame.Description = request.Description;
            dbGame.PriceGb = request.PriceGb;

            await _dataContext.SaveChangesAsync();

            return Ok(await _dataContext.Games.FindAsync(request.Id));
        }

        [HttpDelete, Authorize(Roles = "Admin")]
        public async Task<ActionResult<Game>> Delete(int id)
        {
            var dbGame = await _dataContext.Games.FindAsync(id);
            if (dbGame == null)
                return BadRequest("Game not found");

            _dataContext.Games.Remove(dbGame);
            await _dataContext.SaveChangesAsync();
            return Ok("Game deleted.");

        }

    }
}
