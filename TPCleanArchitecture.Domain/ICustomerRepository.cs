using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPCleanArchitecture.Domain
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        IEnumerable<Movie> GetFavoriteMovies(int customerId);
    }
}
