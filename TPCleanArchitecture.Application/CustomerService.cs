using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPCleanArchitecture.Domain;

namespace TPCleanArchitecture.Application
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customersRepository;
        private readonly IMovieRepository _moviesRepository;

        public CustomerService(ICustomerRepository customersRepository, IMovieRepository moviesRepository)
        {
            _customersRepository = customersRepository;
            _moviesRepository = moviesRepository;
        }

        public Customer GetById(int id) => _customersRepository.GetById(id);

        public IEnumerable<Customer> GetAll()
        {
            var customers = _customersRepository.GetAll();
            
            return customers;
        }

        public void Add(CustomerDto customerDto)
        {
            var favoriteMovies = _moviesRepository.GetMoviesByIds(customerDto.FavoriteMoviesIds);

            var customer = new Customer
            {
                Name = customerDto.Name,
                FavoriteMovies = favoriteMovies.ToList()
            };

            _customersRepository.Add(customer);
        }

        public void Add(Customer customer)
        {
            
        }
        public void Update(Customer customer) => _customersRepository.Update(customer);

        public void Delete(int id) => _customersRepository.Delete(id);

        public IEnumerable<Movie> GetFavoriteMovies(int customerId) => _customersRepository.GetFavoriteMovies(customerId);
    }


}
