using Microsoft.AspNetCore.Authorization;
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
            return Ok(await _dataContext.Publishers.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Publisher>>> Get(int id)
        {
            var dbPub = await _dataContext.Publishers.FindAsync(id);
            if (dbPub == null)
                return BadRequest("Publisher not found.");

            return Ok(dbPub);
        }

        [HttpGet("{id}/games")]
        public async Task<ActionResult<List<Game>>> GetGames(int id)
        {
            return Ok(await _dataContext.Games.Where(game => game.PublisherId == id).ToListAsync());
        }

        [HttpPost, Authorize(Roles = "Admin")]
        public async Task<ActionResult<Publisher>> AddDeveloper(Publisher publisher)
        {
            _dataContext.Publishers.Add(publisher);
            await _dataContext.SaveChangesAsync();
            // Once it is saved, the primary key will be added to the existing developer as an Id, so we can then use it to fetch the newly added developer
            return Ok(await _dataContext.Publishers.FindAsync(publisher.Id));
        }

        [HttpPut, Authorize(Roles = "Admin")]
        public async Task<ActionResult<Publisher>> UpdateDeveloper(Publisher request)
        {
            var dbPub = await _dataContext.Publishers.FindAsync(request.Id);
            if (dbPub == null)
                return BadRequest("Publisher not found.");

            dbPub.Name = request.Name;
            dbPub.Description = request.Description;

            await _dataContext.SaveChangesAsync();

            return Ok(await _dataContext.Publishers.Include(publisher => publisher.Games).ToListAsync());//.FirstOrDefaultAsync(developer => developer.Id == dbDev.Id));
        }

        [HttpDelete, Authorize(Roles = "Admin")]
        public async Task<ActionResult<Publisher>> Delete(int id)
        {
            var dbPub = await _dataContext.Publishers.FindAsync(id);
            if (dbPub == null)
                return BadRequest("Publisher not found");

            _dataContext.Publishers.Remove(dbPub);
            await _dataContext.SaveChangesAsync();
            return Ok(await _dataContext.Publishers.Include(publisher => publisher.Games).ToListAsync());

        }

    }
}
