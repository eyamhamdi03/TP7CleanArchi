using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPCleanArchitecture.Domain;

namespace TPCleanArchitecture.Application
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _moviesRepository;
        private readonly IRepository<Review> _reviewsRepository;

        public MovieService(IMovieRepository moviesRepository, IRepository<Review> reviewsRepository)
        {
            _moviesRepository = moviesRepository;
            _reviewsRepository = reviewsRepository;
        }

        public Movie GetById(int id) => _moviesRepository.GetById(id);

        public IEnumerable<Movie> GetAll() => _moviesRepository.GetAll();

        public void Add(Movie movie) => _moviesRepository.Add(movie);

        public void Update(Movie movie) => _moviesRepository.Update(movie);

        public void Delete(int id) => _moviesRepository.Delete(id);

        public IEnumerable<Movie> GetByGenre(string genre) => _moviesRepository.GetByGenre(genre);

        public double GetAverageRating(int movieId)
        {
            var reviews = _reviewsRepository.GetAll().Where(r => r.MovieId == movieId);
            return reviews.Any() ? reviews.Average(r => r.Rating) : 0;
        }

        public void AddReview(Review review) => _reviewsRepository.Add(review);

        public IEnumerable<Review> GetReviewsForMovie(int movieId)
            => _reviewsRepository.GetAll().Where(r => r.MovieId == movieId);
    }
}