using FinalProjeckt.Data.DTOs;
using FinalProjeckt.Data.Models;
using FinalProjeckt.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjeckt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllCustomer()
        {
            var CustomerDb = FakeDB.CustomerDb.ToList();   
 
            return Ok(CustomerDb);
        }

        [HttpGet("{id}")]
        public IActionResult GetCustomerById(int id)
        {
            var CustomersDb = FakeDB.CustomerDb.FirstOrDefault(x => x.Id == id);

            if (CustomersDb == null)
            {
                return NotFound($"Customer with id = {id} not found");
            }
            else
            {
                return Ok(CustomersDb);
            }
        }

        [HttpDelete("Delete/{id}")]
        public IActionResult DeleteCustomerById(int id)
        {
            var CustomersDb = FakeDB.CustomerDb.FirstOrDefault(x => x.Id == id);
            if (CustomersDb == null)
            {
                return NotFound($"Customer with id = {id} not found");
            }
            else
            {
                FakeDB.CustomerDb.Remove(CustomersDb);
                return Ok($"Customer with id = {id} was removed");
            }
        }
        [HttpPost]
        public IActionResult PostCustomer([FromBody] PostCustomerDto payload)
        {
            var newCustomer = new Customer()
            {
                Id = new Random().Next(10, 100),
                Name = payload.Name,
                ContactPerson = payload.ContactPerson,
                Email = payload.Email,
                Phone = payload.Phone
            };

            FakeDB.CustomerDb.Add(newCustomer);

            return Ok("New user");
        }



        [HttpPut("{id}")]
        public IActionResult UpdateCustomerById(int id, [FromBody] PutCustomerDto payload)
        {
            var CustomersDb = FakeDB.CustomerDb.FirstOrDefault(x => x.Id == id);

            if (CustomersDb == null)
            {
                return NotFound($"Customer with id = {id} not found");
            }
            else
            {
                CustomersDb.Name = payload.Name;
                CustomersDb.ContactPerson = payload.ContactPerson;
                CustomersDb.Email = payload.Email;
                CustomersDb.Phone = payload.Phone;


                return Ok($"Customer with id = {id} was updated");
            }
        }

    }
}



