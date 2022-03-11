using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WmBlazor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public PublisherController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<Publisher>>> Get()
        {
            return Ok(await _dataContext.Publishers.Include(publisher => publisher.Games).ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Publisher>>> Get(int id)
        {
            var dbPub = await _dataContext.Publishers.Include(publisher => publisher.Games).FirstOrDefaultAsync(publisher => publisher.Id == id);
            if (dbPub == null)
                return BadRequest("Publisher not found.");

            return Ok(dbPub);
        }

        [HttpGet("{id}/games")]
        public async Task<ActionResult<List<Game>>> GetGames(int id)
        {
            return Ok(await _dataContext.Games.Where(game => game.PublisherId == id).ToListAsync());
        }

    }
}
