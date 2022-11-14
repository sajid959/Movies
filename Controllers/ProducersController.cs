using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Movies.Models;

namespace Movies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProducersController : ControllerBase
    {
        private readonly MovieContext _dbContext;
        public ProducersController(MovieContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Producer>>> GetProducers()
        {
            if (_dbContext.Producers == null)
            {
                return NotFound();
            }
            return await _dbContext.Producers.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Actor>> PostProducers(Producer producer)
        {
            _dbContext.Producers.Add(producer);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProducers), new { id = producer.Prod_Id }, producer);
        }
    }
}
