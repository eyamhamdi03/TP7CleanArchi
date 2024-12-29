using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPCleanArchitecture.Domain;

namespace TPCleanArchitecture.Application
{
    public interface ICustomerService : IService<Customer>
    {
        public void Add(CustomerDto customerDto);
        IEnumerable<Movie> GetFavoriteMovies(int customerId);
    }
}
