using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPCleanArchitecture.Domain;

namespace TPCleanArchitecture.Application
{
    public interface IMovieService : IService<Movie>
    {
        IEnumerable<Movie> GetByGenre(string genre);
        double GetAverageRating(int movieId);
        void AddReview(Review review);
        IEnumerable<Review> GetReviewsForMovie(int movieId);
    }
}
