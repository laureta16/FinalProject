using FinalProjeckt.Data;
using FinalProjeckt.Data.DTOs;
using FinalProjeckt.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace FinalProjeckt.Services
{

    public class CustomerService : ICustomerService
    {
        private AppDbContext _dbContext;

        public CustomerService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Customer>> GetCustomerAsync()
        {
            var allCustomer = await _dbContext.Customer.ToListAsync();
            return allCustomer;
        }

        public async Task<Customer> GetCustomerByIdAsync(int id)
        {
            var CustomerFromDb = await _dbContext.Customer.FirstOrDefaultAsync(x => x.Id == id);
            return CustomerFromDb;
        }

        public async Task PostCustomerAsync(PostCustomerDto customer)
        {
            var newCustomer = new Customer()
            {
                Name = customer.Name,
                ContactPerson = customer.ContactPerson,
                Email = customer.Email,
                Phone = customer.Phone,


            };

            await _dbContext.Customer.AddAsync(newCustomer);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Customer> UpdateCustomerAsync(int id, PutCustomerDto customer)
        {
            var customerFromDb = await _dbContext.Customer.FirstOrDefaultAsync(x => x.Id == id);

            if (customerFromDb != null)
            {
                customerFromDb.Name = customer.Name;
                customerFromDb.ContactPerson = customer.ContactPerson;
                customerFromDb.Email = customer.Email;
                customerFromDb.Phone = customer.Phone;

                await _dbContext.SaveChangesAsync();
            }

            return customerFromDb;
        }

        public async Task DeleteCustomerByIdAsync(int id)
        {
            var customerFromDb = await _dbContext.Customer.FirstOrDefaultAsync(x => x.Id == id);

            if (customerFromDb != null)
            {
                _dbContext.Customer.Remove(customerFromDb);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
