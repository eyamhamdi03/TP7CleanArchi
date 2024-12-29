using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
namespace TPCleanArchitecture.Domain
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
      
        public List<Movie>? FavoriteMovies { get; set; } = new List<Movie>();

    }
}

