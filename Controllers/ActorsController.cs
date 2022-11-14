using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Movies.Models;

namespace Movies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorsController : ControllerBase
    {
        private readonly MovieContext _dbContext;
        public ActorsController(MovieContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Actor>>> GetActors()
        {
            if (_dbContext.Actors == null)
            {
                return NotFound();
            }
            return await _dbContext.Actors.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Actor>> PostActor(Actor actor)
        {
            _dbContext.Actors.Add(actor);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetActors), new { id = actor.Actor_Id }, actor);
        }
    }
}
