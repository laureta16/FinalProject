using FinalProjeckt.Data.DTOs;
using FinalProjeckt.Data.Models;
using static System.Reflection.Metadata.BlobBuilder;

namespace FinalProjeckt.Services;

public interface ICustomerService
{
    Task<List<Customer>> GetCustomerAsync();
    Task<Customer> GetCustomerByIdAsync(int id);
    Task PostCustomerAsync(PostCustomerDto customer);
    Task<Customer> UpdateCustomerAsync(int id, PutCustomerDto customer);
    Task DeleteCustomerByIdAsync(int id);
}
