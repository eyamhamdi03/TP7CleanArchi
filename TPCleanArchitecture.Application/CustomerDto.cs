using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPCleanArchitecture.Application
{
   
   public class CustomerDto
    {
        public string Name { get; set; }  // Customer's name
        public List<int> FavoriteMoviesIds { get; set; }  // List of movie IDs for the customer's favorite movies
    }

}
