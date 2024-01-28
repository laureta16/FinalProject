using FinalProjeckt.Data.DTOs;
using FinalProjeckt.Data.Models;
using FinalProjeckt.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FinalProjeckt.Services;

namespace FinalProjeckt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CustomerController : ControllerBase
    {

        private ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCustomer()
        {
            var customerDb = await _customerService.GetCustomerAsync();

            return Ok(customerDb);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerById(int id)
        {
            var customerDb = await _customerService.GetCustomerByIdAsync(id);

            if (customerDb == null)
            {
                return NotFound($"Customer with id = {id} not found");
            }
            else
            {
                return Ok(customerDb);
            }
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteCustomerById(int id)
        {
            await _customerService.DeleteCustomerByIdAsync(id);

            return Ok("Deleted");
        }
        [HttpPost]
        public async Task<IActionResult> PostCustomer([FromBody] PostCustomerDto payload)
        {
            await _customerService.PostCustomerAsync(payload);

            return Ok("New Customer created");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomerById(int id, [FromBody] PutCustomerDto payload)
        {
            await _customerService.UpdateCustomerAsync(id, payload);

            return Ok($"Customer with id = {id} was updated");
        }
    }
}