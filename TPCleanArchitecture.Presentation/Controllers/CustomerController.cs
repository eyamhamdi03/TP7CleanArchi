using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TPCleanArchitecture.Application;
using TPCleanArchitecture.Domain;

namespace TPCleanArchitecture.Presentation.Controllers
{
    [ApiController]
    [Route("api/customers")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customersService;

        public CustomersController(ICustomerService customersService)
        {
            _customersService = customersService;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id) => Ok(_customersService.GetById(id));
        [HttpGet]
        
        public ActionResult<IEnumerable<Customer>> GetAll()
        {
            var customers = _customersService.GetAll();
          
            return Ok(customers);
        }


        [HttpPost]
        public ActionResult<Customer> Add([FromBody] CustomerDto customerDto)
        {
            // Pass CustomerDto to the unified Add method
            _customersService.Add(customerDto);
            return Ok(new { Message = "Customer created successfully" });
        }
        [HttpPut]
        public IActionResult Update([FromBody] Customer customer)
        {
            _customersService.Update(customer);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _customersService.Delete(id);
            return NoContent();
        }

        [HttpGet("{id}/favorite-movies")]
        public IActionResult GetFavoriteMovies(int id) => Ok(_customersService.GetFavoriteMovies(id));
    }



}
