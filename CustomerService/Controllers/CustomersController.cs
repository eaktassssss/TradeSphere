using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CustomerService.Application.Interfaces.Services;
using CustomerService.Application.Contract.Request.Customer;

namespace CustomerService.Controllers
{
    [Route("api/")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        ICustomerService _customerService;
        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        [HttpPost]
        [Route("customer")]
        public async Task<IActionResult> CreateAsync(CreateCustomerRequest createCustomerRequest)
        {
            var response = await _customerService.CreateAsync(createCustomerRequest);
            return Ok(response);
        }
        [HttpGet]
        [Route("customer/{id}")]
        public async Task<IActionResult> GetSingleAsync(int id)
        {
            var response = await _customerService.GetSingleAsync(id);
            return Ok(response);
        }
    }
}
