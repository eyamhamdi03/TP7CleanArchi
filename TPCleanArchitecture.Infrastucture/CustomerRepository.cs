using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPCleanArchitecture.Domain;
using TPCleanArchitecture.Infrastucture;

namespace TPCleanArchitecture.Infrastructure
{

public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        private readonly AppDBContext _context;

        public CustomerRepository(AppDBContext context) : base(context) {
            _context = context;
        }
        public IEnumerable<Customer> GetAll()
        {
            return _context.Customers
                           .Include(c => c.FavoriteMovies)  // Eagerly load FavoriteMovies
                           .ToList();
        }

        public IEnumerable<Movie> GetFavoriteMovies(int customerId)
        {
            var customer = GetById(customerId);
            return customer?.FavoriteMovies ?? new List<Movie>();
        }
    }
}
