using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movies.Models;
using Microsoft.EntityFrameworkCore;

namespace Movies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly MovieContext _dbContext;

        public MoviesController(MovieContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet]

        public async Task<ActionResult<IEnumerable<MovieDetails>>> GetAll()
        {
            List<Actor> actor = _dbContext.Actors.ToList();
            List<Movie> movie = _dbContext.Movies.ToList();
            List<Producer> prod = _dbContext.Producers.ToList();
            var query = (from a in _dbContext.Actors
                         join
                   m in _dbContext.Movies on a.Movie_id equals m.Id
                         join p in _dbContext.Producers on m.Producer_Id equals p.Prod_Id
                         select new MovieDetails()
                         {
                             Id = m.Id,
                             MovieName = m.MovieName,
                             ReleaseDate = m.ReleaseDate,
                             Producer_Name = p.ProdName,
                             Actor_name = a.ActorName
                         }).ToList();
            return query;
        }

        // GET: api/Movies
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Movie>>> GetMovies()
        //{
        //    if (_dbContext.Movies == null)
        //    {
        //        return NotFound();
        //    }
        //    return await _dbContext.Movies.ToListAsync();

        //}

        // POST: api/Movies
        [HttpPost]
        public async Task<ActionResult<Movie>> PostMovie(Movie movie)
        {
            _dbContext.Movies.Add(movie);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAll), new { id = movie.Id }, movie);
        }
        //PUT: api/Movies
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovie(int id, Movie movie)
        {
            if (id != movie.Id)
            {
                return BadRequest();
            }

            _dbContext.Entry(movie).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        private bool MovieExists(long id)
        {
            return (_dbContext.Movies?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
