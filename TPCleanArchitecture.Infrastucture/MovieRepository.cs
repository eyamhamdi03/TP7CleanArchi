using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;
using Octokit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPCleanArchitecture.Domain;
using TPCleanArchitecture.Infrastucture;

namespace TPCleanArchitecture.Infrastructure
{
    public class MovieRepository : Repository<Movie>, IMovieRepository
    {
        private readonly AppDBContext _context;

        public MovieRepository(AppDBContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Movie> GetByGenre(string genre) => _context.Movies.Where(m => m.Genre == genre).ToList();
        public IEnumerable<Movie> GetMoviesByIds(List<int> movieIds)
        {
            return _context.Movies
                           .Where(m => movieIds.Contains(m.Id))
                           .ToList();
        }
    }

   
}
