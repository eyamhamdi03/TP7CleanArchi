using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TPCleanArchitecture.Application;
using TPCleanArchitecture.Domain;

namespace TPCleanArchitecture.Presentation.Controllers
{
    [ApiController]
    [Route("api/movies")]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _moviesService;

        public MovieController(IMovieService moviesService)
        {
            _moviesService = moviesService;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var movie = _moviesService.GetById(id);
            if (movie == null)
            {
                return NotFound(); // Return 404 if not found
            }
            return Ok(movie);
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_moviesService.GetAll());

        [HttpPost]
        public IActionResult Add([FromBody] Movie movie)
        {
            _moviesService.Add(movie);
            return CreatedAtAction(nameof(GetById), new { id = movie.Id }, movie);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Movie movie)
        {
            var existingMovie = _moviesService.GetById(id);
            if (existingMovie == null)
            {
                return NotFound(); // Return 404 if the movie doesn't exist
            }
            movie.Id = id; // Ensure the movie has the correct ID
            _moviesService.Update(movie);
            return NoContent(); // Return 204 No Content on successful update
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var movie = _moviesService.GetById(id);
            if (movie == null)
            {
                return NotFound(); // Return 404 if the movie doesn't exist
            }
            _moviesService.Delete(id);
            return NoContent(); // Return 204 No Content on successful deletion
        }

        [HttpGet("genre/{genre}")]
        public IActionResult GetByGenre(string genre) => Ok(_moviesService.GetByGenre(genre));

        [HttpGet("{id}/average-rating")]
        public IActionResult GetAverageRating(int id)
        {
            var averageRating = _moviesService.GetAverageRating(id);
            return Ok(averageRating);
        }

        [HttpPost("{id}/review")]
        public IActionResult AddReview(int id, [FromBody] Review review)
        {
            review.MovieId = id;
            _moviesService.AddReview(review);
            return CreatedAtAction(nameof(GetReviewsForMovie), new { id = id }, review);
        }

        [HttpGet("{id}/reviews")]
        public IActionResult GetReviewsForMovie(int id)
        {
            var reviews = _moviesService.GetReviewsForMovie(id);
            return Ok(reviews);
        }
    }
}
