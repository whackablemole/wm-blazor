using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WmBlazor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeveloperController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public DeveloperController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<Developer>>> Get()
        {
            return Ok(await _dataContext.Developers.Include(developer => developer.Games).ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Developer>>> Get(int id)
        {
            var dbDev = await _dataContext.Developers.Include(developer => developer.Games).FirstOrDefaultAsync(developer => developer.Id == id);
            if (dbDev == null)
                return BadRequest("Developer not found.");

            return Ok(dbDev);
        }

        [HttpGet("{id}/games")]
        public async Task<ActionResult<List<Game>>> GetGames(int id)
        {
            return Ok(await _dataContext.Games.Where(game => game.DeveloperId == id).ToListAsync());
        }

        [HttpPost, Authorize(Roles = "Admin")]
        public async Task<ActionResult<Developer>> AddDeveloper(Developer developer)
        {
            _dataContext.Developers.Add(developer);
            await _dataContext.SaveChangesAsync();
            // Once it is saved, the primary key will be added to the existing developer as an Id, so we can then use it to fetch the newly added developer
            return Ok(await _dataContext.Developers.FindAsync(developer.Id));
        }

        [HttpPut, Authorize(Roles = "Admin")]
        public async Task<ActionResult<Developer>> UpdateDeveloper(Developer request)
        {
            var dbDev = await _dataContext.Developers.FindAsync(request.Id);
            if (dbDev == null)
                return BadRequest("Developer not found.");

            dbDev.Name = request.Name;
            dbDev.Description = request.Description;

            await _dataContext.SaveChangesAsync();

            return Ok(await _dataContext.Developers.Include(developer => developer.Games).ToListAsync());//.FirstOrDefaultAsync(developer => developer.Id == dbDev.Id));
        }

        [HttpDelete, Authorize(Roles = "Admin")]
        public async Task<ActionResult<Developer>> Delete(int id)
        {
            var dbDev = await _dataContext.Developers.FindAsync(id);
            if (dbDev == null)
                return BadRequest("Developer not found");

            _dataContext.Developers.Remove(dbDev);
            await _dataContext.SaveChangesAsync();
            return Ok(await _dataContext.Developers.Include(developer => developer.Games).ToListAsync());

        }

    }
}
