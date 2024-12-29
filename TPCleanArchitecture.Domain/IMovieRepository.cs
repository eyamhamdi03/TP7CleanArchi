using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPCleanArchitecture.Domain
{
    public interface IMovieRepository : IRepository<Movie>
    {
        IEnumerable<Movie> GetByGenre(string genre);
        IEnumerable<Movie> GetMoviesByIds(List<int> movieIds);
    }
}


